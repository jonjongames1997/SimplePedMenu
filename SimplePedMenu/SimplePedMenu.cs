using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;
using NativeUI;
using static GTA.ScriptSettings;

public class SimplePedMenu : Script
{
    //region // General Variables //
    private Ped playerPed = Game.Player.Character;
    private Player player = Game.Player;

    private readonly ObjectPool _objectPool;
    private readonly ScriptSettings config;
    private readonly Keys OpenMenu;
    private readonly NativeMenu _mainMenu;

    private readonly List<int> favoritePedModels = new List<int>();
    private readonly List<int> favoriteVehicleModels = new List<int>();

    private const string FavoritesPedsSection = "FavoritesPeds";
    private const string FavoritesVehiclesSection = "FavoritesVehicles";
    private const string FavoritesKey = "Models";
    // New features
    private readonly List<Ped> _squad = new List<Ped>();
    private const string SquadSection = "Squad";
    private const string LoadoutsSection = "Loadouts";
    private const string CheatsSection = "Cheats";
    private string language = "en";
    private bool hotkeysEnabled = true;
    //endregion

    //region // Favorites Helpers //
    private void LoadFavorites()
    {
        // Read CSV lists of hashes from INI
        string pedCsv = config.GetValue(FavoritesPedsSection, FavoritesKey, "");
        string vehCsv = config.GetValue(FavoritesVehiclesSection, FavoritesKey, "");

        favoritePedModels.Clear();
        favoriteVehicleModels.Clear();

        if (!string.IsNullOrWhiteSpace(pedCsv))
        {
            foreach (var part in pedCsv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(part.Trim(), out int hash))
                    favoritePedModels.Add(hash);
            }
        }

        if (!string.IsNullOrWhiteSpace(vehCsv))
        {
            foreach (var part in vehCsv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(part.Trim(), out int hash))
                    favoriteVehicleModels.Add(hash);
            }
        }
    }

    private void SaveFavorites()
    {
        string pedCsv = string.Join(",", favoritePedModels);
        string vehCsv = string.Join(",", favoriteVehicleModels);

        config.SetValue(FavoritesPedsSection, FavoritesKey, pedCsv);
        config.SetValue(FavoritesVehiclesSection, FavoritesKey, vehCsv);
        config.Save();
    }

    private string HashToHexLabel(int hash)
    {
        return $"0x{hash:X8}";
    }

    private string VehicleNameFromHash(int hash)
    {
        var model = new Model(hash);
        if (!model.IsInCdImage || !model.IsValid || !model.IsVehicle)
            return $"Vehicle {HashToHexLabel(hash)}";

        // Try to get a friendly display name from the game
        string displayName = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, hash);
        if (!string.IsNullOrWhiteSpace(displayName))
        {
            string localized = Game.GetLocalizedString(displayName);
            if (!string.IsNullOrWhiteSpace(localized) && localized != "NULL")
                return $"{localized} ({HashToHexLabel(hash)})";

            return $"{displayName} ({HashToHexLabel(hash)})";
        }

        return $"Vehicle {HashToHexLabel(hash)}";
    }

    private string PedLabelFromHash(int hash)
    {
        var model = new Model(hash);
        if (!model.IsInCdImage || !model.IsValid || !model.IsPed)
            return $"Ped {HashToHexLabel(hash)}";

        // Model.ToString() usually gives the internal name if known
        string name = model.ToString();
        if (!string.IsNullOrWhiteSpace(name))
            return $"{name} ({HashToHexLabel(hash)})";

        return $"Ped {HashToHexLabel(hash)}";
    }
    //endregion

    //region // New Feature Helpers //
    private void EnsureIniSchema(ScriptSettings cfg)
    {
        bool changed = false;
        if (string.IsNullOrEmpty(cfg.GetValue<string>("Options", "Language", null)))
        {
            cfg.SetValue("Options", "Language", "en");
            changed = true;
        }

        if (cfg.GetValue<string>(FavoritesPedsSection, "Hotkeys", null) == null)
        {
            cfg.SetValue(FavoritesPedsSection, "Hotkeys", "1=,2=,3=,4=,5=");
            changed = true;
        }

        if (cfg.GetValue<string>(FavoritesVehiclesSection, "Hotkeys", null) == null)
        {
            cfg.SetValue(FavoritesVehiclesSection, "Hotkeys", "1=,2=,3=,4=,5=");
            changed = true;
        }

        if (cfg.GetValue<string>(CheatsSection, "InfiniteHealth", null) == null)
        {
            cfg.SetValue(CheatsSection, "InfiniteHealth", "false");
            cfg.SetValue(CheatsSection, "InfiniteAmmo", "false");
            cfg.SetValue(CheatsSection, "NoWanted", "false");
            changed = true;
        }

        if (changed)
            cfg.Save();

        language = cfg.GetValue<string>("Options", "Language", "en");
        hotkeysEnabled = cfg.GetValue<bool>("Options", "HotkeysEnabled", true);
    }

    private string T(string key, string defaultValue = null)
    {
        // Simple localization: read from [Locale.<lang>] section if present
        string localeSection = $"Locale.{language}";
        var val = config.GetValue<string>(localeSection, key, null);
        if (!string.IsNullOrEmpty(val))
            return val;

        // If missing, write default back to INI so translators can edit
        if (defaultValue != null)
        {
            try
            {
                config.SetValue(localeSection, key, defaultValue);
                config.Save();
            }
            catch { }
            return defaultValue;
        }

        return key;
    }

    //region // Companion Manager //
    private void SpawnCompanion(string modelName)
    {
        try
        {
            var model = new Model(modelName);
            if (!model.IsInCdImage || !model.IsValid || !model.IsPed)
            {
                BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "Invalid companion model.");
                return;
            }

            Vector3 spawnPos = Game.Player.Character.Position + Game.Player.Character.ForwardVector * 2f;
            Ped ped = World.CreatePed(model, spawnPos);
            if (ped != null && ped.Exists())
            {
                ped.Weapons.Give(WeaponHash.Pistol, 250, true, true);
                ped.Armor = 100;
                ped.RelationshipGroup = "COMPANIONS";
                ped.KeepTaskWhenMarkedAsNoLongerNeeded = true;
                ped.Task.FollowToOffsetFromEntity(Game.Player.Character, new Vector3(1f, 1f, 0f), 2f);
                _squad.Add(ped);
                BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "Companion spawned.");
            }
        }
        catch (Exception)
        {
            BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "Failed to spawn companion.");
        }
    }

    private void GiveSquadFollow()
    {
        for (int i = 0; i < _squad.Count; i++)
        {
            var ped = _squad[i];
            if (ped == null || !ped.Exists()) continue;
            Vector3 offset = new Vector3(1f + i, 0f, 0f);
            ped.Task.FollowToOffsetFromEntity(Game.Player.Character, offset, 2f);
        }
        BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "Squad ordered to follow.");
    }

    private void GiveSquadGuard()
    {
        foreach (var ped in _squad)
        {
            if (ped == null || !ped.Exists()) continue;
            ped.Task.ClearAll();
            ped.Task.StandStill(-1);
            ped.BlockPermanentEvents = true;
        }
        BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "Squad ordered to guard position.");
    }

    private void GiveSquadAttackNearest()
    {
        // find nearest ped to player
        Ped nearest = World.GetClosestPed(Game.Player.Character.Position, 30f);
        if (nearest == null || !nearest.Exists())
        {
            BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "No valid target nearby.");
            return;
        }

        foreach (var ped in _squad)
        {
            if (ped == null || !ped.Exists()) continue;
            try
            {
                ped.Task.CombatHatedTargetsAroundPed(1000f);
            }
            catch
            {
                // fallback: use native task
                Function.Call(Hash.TASK_COMBAT_PED, ped.Handle, nearest.Handle, 0, 16);
            }
        }
        BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "Squad ordered to attack nearest.");
    }

    private void SaveCurrentSquadPreset()
    {
        if (_squad.Count == 0)
        {
            BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "No companions to save.");
            return;
        }

        var list = new List<string>();
        foreach (var ped in _squad)
        {
            if (ped != null && ped.Exists())
            {
                list.Add(ped.Model.Hash.ToString());
            }
        }
        string csv = string.Join(",", list);

        string listKey = config.GetValue<string>("SquadPresets", "PresetsList", "");
        int nextIndex = 1;
        var names = new List<string>();
        if (!string.IsNullOrWhiteSpace(listKey))
            names = listKey.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string name;
        do
        {
            name = "Preset" + nextIndex;
            nextIndex++;
        } while (names.Contains(name));

        names.Add(name);
        config.SetValue("SquadPresets", "PresetsList", string.Join(",", names));
        config.SetValue("SquadPresets", name, csv);
        config.Save();

        BigMessageThread.MessageInstance.ShowSimpleShard("Squad", $"Saved preset {name}.");
    }

    private void BuildSquadPresetsMenu(NativeMenu menu)
    {
        menu.Clear();
        string listKey = config.GetValue<string>("SquadPresets", "PresetsList", "");
        if (string.IsNullOrWhiteSpace(listKey))
        {
            menu.Add(new NativeItem("No presets saved.", "Save current squad as a preset."));
            return;
        }

        var names = listKey.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var n in names)
        {
            string csv = config.GetValue<string>("SquadPresets", n, "");
            var item = new NativeItem($"Load {n}", $"Spawn companions from preset {n}");
            menu.Add(item);
            item.Activated += (s, a) =>
            {
                DismissSquad();
                foreach (var part in csv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (int.TryParse(part.Trim(), out int h))
                    {
                        var model = new Model(h);
                        if (model.IsValid && model.IsPed)
                        {
                            SpawnCompanion(model.ToString());
                        }
                    }
                }
            };

            var del = new NativeItem($"Delete {n}", $"Delete preset {n}");
            menu.Add(del);
            del.Activated += (s, a) =>
            {
                var list = names.ToList();
                list.Remove(n);
                config.SetValue("SquadPresets", "PresetsList", string.Join(",", list));
                // clear preset value
                config.SetValue("SquadPresets", n, "");
                config.Save();
                BuildSquadPresetsMenu(menu);
            };
        }
    }
    //endregion

    //region // Squad Handler //
    private void DismissSquad()
    {
        foreach (var ped in _squad.ToList())
        {
            if (ped != null && ped.Exists())
            {
                ped.Delete();
            }
        }
        _squad.Clear();
        BigMessageThread.MessageInstance.ShowSimpleShard("Squad", "All companions dismissed.");
    }
    //endregion

    //region // Loadout Applier //
    private void ApplyLoadout(string loadoutCsv)
    {
        // Format: WEAPON_NAME:ammo,WEAPON_NAME2:ammo2
        var parts = loadoutCsv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var part in parts)
        {
            var kv = part.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (kv.Length >= 1)
            {
                string w = kv[0].Trim();
                int ammo = 9999;
                if (kv.Length == 2) int.TryParse(kv[1].Trim(), out ammo);

                try
                {
                    int hash = Function.Call<int>(Hash.GET_HASH_KEY, w);
                    Game.Player.Character.Weapons.Give((WeaponHash)hash, ammo, false, true);
                }
                catch { }
            }
        }
    }
    //endregion

    //region // Enforce Cheats //
    private void EnforceCheats()
    {
        bool infHealth = config.GetValue<bool>(CheatsSection, "InfiniteHealth", false);
        bool infAmmo = config.GetValue<bool>(CheatsSection, "InfiniteAmmo", false);
        bool noWanted = config.GetValue<bool>(CheatsSection, "NoWanted", false);

        if (infHealth)
        {
            Game.Player.Character.Health = Game.Player.Character.MaxHealth;
            Game.Player.Character.Armor = 100;
        }

        if (infAmmo)
        {
            // Refill current weapon ammo and set clip count high
            var weapon = Game.Player.Character.Weapons.Current;
            if (weapon != null && weapon.Hash != 0)
            {
                weapon.Ammo = Math.Max(weapon.Ammo, 9999);
            }
        }

        if (noWanted)
        {
            if (Game.Player.WantedLevel > 0)
                Game.Player.WantedLevel = 0;
        }
    }
    //endregion

    //region // Hotkey Handler //
    private void HandleHotkeys(Keys key)
    {
        if (!hotkeysEnabled) return;

        // numeric keys  D1..D5 map to favorites indices 0..4
        int idx = -1;
        if (key >= Keys.D1 && key <= Keys.D9)
            idx = key - Keys.D1; // 0-based
        else if (key >= Keys.NumPad1 && key <= Keys.NumPad9)
            idx = key - Keys.NumPad1;

        if (idx >= 0)
        {
            if (idx < favoritePedModels.Count)
            {
                int hash = favoritePedModels[idx];
                var model = new Model(hash);
                if (model.IsValid && model.IsPed)
                    Game.Player.ChangeModel(model);
            }
            else if (idx < favoriteVehicleModels.Count)
            {
                int hash = favoriteVehicleModels[idx];
                var model = new Model(hash);
                if (model.IsValid && model.IsVehicle)
                {
                    Vehicle v = World.CreateVehicle(model, Game.Player.Character.Position);
                    if (v != null && v.Exists())
                        Game.Player.Character.SetIntoVehicle(v, VehicleSeat.Driver);
                }
            }
        }
    }
    //endregion

    //region // Favorites Menu //
    public void FavoritesMenu(NativeMenu menu)
    {
        var favoritesMenu = new NativeMenu("Favorites", "Pinned peds & vehicles");
        _objectPool.Add(favoritesMenu);
        menu.AddSubMenu(favoritesMenu);

        // Submenu for favorite peds
        var favPedsMenu = new NativeMenu("Favorite Peds", "Quick access to ped models");
        _objectPool.Add(favPedsMenu);
        favoritesMenu.AddSubMenu(favPedsMenu);

        // Submenu for favorite vehicles
        var favVehMenu = new NativeMenu("Favorite Vehicles", "Quick access to vehicles");
        _objectPool.Add(favVehMenu);
        favoritesMenu.AddSubMenu(favVehMenu);

        // --- Add Current Ped ---
        var addCurrentPed = new NativeItem("Add Current Ped to Favorites", "");
        favoritesMenu.Add(addCurrentPed);
        addCurrentPed.Activated += (sender, args) =>
        {
            int currentPedHash = Game.Player.Character.Model.Hash;
            if (!favoritePedModels.Contains(currentPedHash))
            {
                favoritePedModels.Add(currentPedHash);
                SaveFavorites();
                BigMessageThread.MessageInstance.ShowSimpleShard(
                    "Favorites",
                    "Current ped added to favorites."
                );

                // Rebuild ped favorites submenu
                RebuildFavoritePedsMenu(favPedsMenu);
            }
            else
            {
                BigMessageThread.MessageInstance.ShowSimpleShard(
                    "Favorites",
                    "Current ped is already in favorites."
                );
            }
        };

        // --- Add Current Vehicle ---
        var addCurrentVehicle = new NativeItem("Add Current Vehicle to Favorites", "");
        favoritesMenu.Add(addCurrentVehicle);
        addCurrentVehicle.Activated += (sender, args) =>
        {
            Vehicle veh = Game.Player.Character.CurrentVehicle;
            if (veh == null || !veh.Exists())
            {
                BigMessageThread.MessageInstance.ShowSimpleShard(
                    "Favorites",
                    "You are not in a vehicle."
                );
                return;
            }

            int modelHash = veh.Model.Hash;
            if (!favoriteVehicleModels.Contains(modelHash))
            {
                favoriteVehicleModels.Add(modelHash);
                SaveFavorites();
                BigMessageThread.MessageInstance.ShowSimpleShard(
                    "Favorites",
                    "Current vehicle added to favorites."
                );

                // Rebuild vehicle favorites submenu
                RebuildFavoriteVehiclesMenu(favVehMenu);
            }
            else
            {
                BigMessageThread.MessageInstance.ShowSimpleShard(
                    "Favorites",
                    "Current vehicle is already in favorites."
                );
            }
        };

        // Build initial favorites lists
        RebuildFavoritePedsMenu(favPedsMenu);
        RebuildFavoriteVehiclesMenu(favVehMenu);

        // Hotkeys info
        var hotkeyInfo = new NativeItem("Hotkeys: Press 1-5 to use favorites", "Enable in INI under Options:HotkeysEnabled");
        favoritesMenu.Add(hotkeyInfo);
    }

    private void RebuildFavoritePedsMenu(NativeMenu menu)
    {
        menu.Clear();

        if (favoritePedModels.Count == 0)
        {
            menu.Add(new NativeItem("No favorite peds yet.", "Use 'Add Current Ped to Favorites' in the Favorites menu."));
            return;
        }

        foreach (int hash in favoritePedModels)
        {
            string label = PedLabelFromHash(hash);
            var item = new NativeItem(label, "Change player model to this favorite");
            menu.Add(item);

            item.Activated += (sender, args) =>
            {
                var model = new Model(hash);
                if (!model.IsInCdImage || !model.IsValid)
                {
                    BigMessageThread.MessageInstance.ShowSimpleShard(
                        "Favorites",
                        "Ped model is invalid or not loaded."
                    );
                    return;
                }

                Game.Player.ChangeModel(model);
            };
        }

        // Clear favorites option
        var clearItem = new NativeItem("Clear Favorite Peds", "");
        menu.Add(clearItem);
        clearItem.Activated += (sender, args) =>
        {
            favoritePedModels.Clear();
            SaveFavorites();
            menu.Clear();
            menu.Add(new NativeItem("No favorite peds yet.", "Use 'Add Current Ped to Favorites' in the Favorites menu."));
            BigMessageThread.MessageInstance.ShowSimpleShard(
                "Favorites",
                "All favorite peds cleared."
            );
        };
    }

    private void RebuildFavoriteVehiclesMenu(NativeMenu menu)
    {
        menu.Clear();

        if (favoriteVehicleModels.Count == 0)
        {
            menu.Add(new NativeItem("No favorite vehicles yet.", "Use 'Add Current Vehicle to Favorites' in the Favorites menu."));
            return;
        }

        foreach (int hash in favoriteVehicleModels)
        {
            string label = VehicleNameFromHash(hash);
            var item = new NativeItem(label, "Spawn this favorite vehicle");
            menu.Add(item);

            item.Activated += (sender, args) =>
            {
                var model = new Model(hash);
                if (!model.IsInCdImage || !model.IsValid || !model.IsVehicle)
                {
                    BigMessageThread.MessageInstance.ShowSimpleShard(
                        "Favorites",
                        "Vehicle model is invalid or not loaded."
                    );
                    return;
                }

                Vehicle vehicle = World.CreateVehicle(model, Game.Player.Character.Position);
                if (vehicle != null && vehicle.Exists())
                {
                    Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
                }
                else
                {
                    BigMessageThread.MessageInstance.ShowSimpleShard(
                        "Favorites",
                        "Failed to spawn vehicle."
                    );
                }
            };
        }

        // Clear favorites option
        var clearItem = new NativeItem("Clear Favorite Vehicles", "");
        menu.Add(clearItem);
        clearItem.Activated += (sender, args) =>
        {
            favoriteVehicleModels.Clear();
            SaveFavorites();
            menu.Clear();
            menu.Add(new NativeItem("No favorite vehicles yet.", "Use 'Add Current Vehicle to Favorites' in the Favorites menu."));
            BigMessageThread.MessageInstance.ShowSimpleShard(
                "Favorites",
                "All favorite vehicles cleared."
            );
        };
    }
    //endregion

    //region // Ped Model Menu //
    public void PlayerModelMenu(NativeMenu menu)
    {
        NativeMenu uimenu = new NativeMenu("Peds", "View Ped Menu");
        _objectPool.Add(uimenu);
        menu.AddSubMenu(uimenu);

        NativeItem femaleTopless = new NativeItem("Female Topless 1", "");
        uimenu.Add(femaleTopless);
        femaleTopless.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("A_F_Y_TOPLESS_01");
        };

        NativeItem tonyaHooker = new NativeItem("Tonya", "");
        uimenu.Add(tonyaHooker);
        tonyaHooker.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_TONYA");
        };

        NativeItem karenDaniels = new NativeItem("Karen Daniels", "");
        uimenu.Add(karenDaniels);
        karenDaniels.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_MICHELLE");
        };

        NativeItem tourist = new NativeItem("Female Tourist 01", "");
        uimenu.Add(tourist);
        tourist.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("A_F_Y_TOURIST_01");
        };

        NativeItem vagosGirl01 = new NativeItem("Female Vagos 1", "");
        uimenu.Add(vagosGirl01);
        vagosGirl01.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("G_F_Y_VAGOS_01");
        };

        NativeItem ashleyCrackhead = new NativeItem("Ashley", "");
        uimenu.Add(ashleyCrackhead);
        ashleyCrackhead.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_ASHLEY");
        };

        NativeItem grandpa = new NativeItem("Grandpa", "");
        uimenu.Add(grandpa);
        grandpa.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("A_M_O_GENSTREET_01");
        };

        NativeItem sexyPoppy = new NativeItem("Poppy Mitchell", "");
        uimenu.Add(sexyPoppy);
        sexyPoppy.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("U_F_Y_POPPYMICH");
        };

        NativeItem sexyMaryAnn = new NativeItem("Mary Ann", "");
        uimenu.Add(sexyMaryAnn);
        sexyMaryAnn.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_MARYANN");
        };

        NativeItem jewelstoreLady = new NativeItem("Jewel Store Lady", "");
        uimenu.Add(jewelstoreLady);
        jewelstoreLady.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_JEWELASS");
        };

        NativeItem sexyHooker01 = new NativeItem("Hooker 1", "");
        uimenu.Add(sexyHooker01);
        sexyHooker01.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_F_Y_HOOKER_01");
        };

        NativeItem sexyHooker02 = new NativeItem("Hooker 2", "");
        uimenu.Add(sexyHooker02);
        sexyHooker02.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_F_Y_HOOKER_02");
        };

        NativeItem sexyHooker03 = new NativeItem("Hooker 3", "");
        uimenu.Add(sexyHooker03);
        sexyHooker03.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_F_Y_HOOKER_03");
        };

        NativeItem abigail = new NativeItem("Abigail", "");
        uimenu.Add(abigail);
        abigail.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_ABIGAIL");
        };

        NativeItem anita = new NativeItem("Anita", "");
        uimenu.Add(anita);
        anita.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("CSB_ANITA");
        };

        NativeItem barTender = new NativeItem("Bartender", "");
        uimenu.Add(barTender);
        barTender.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_F_Y_BARTENDER_01");
        };

        NativeItem impotentRage = new NativeItem("Impotent Rage", "");
        uimenu.Add(impotentRage);
        impotentRage.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("U_M_Y_IMPORAGE");
        };

        NativeItem airhostess = new NativeItem("Air Hostess", "");
        uimenu.Add(airhostess);
        airhostess.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_F_Y_AIRHOSTESS_01");
        };

        NativeItem aldiNapoli = new NativeItem("Aldinapoli", "");
        uimenu.Add(aldiNapoli);
        aldiNapoli.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("U_M_M_ALDINAPOLI");
        };

        NativeItem gunshopOwner = new NativeItem("Gun Shop Owner", "");
        uimenu.Add(gunshopOwner);
        gunshopOwner.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_M_Y_AMMUCITY_01");
        };

        NativeItem femaleBallas = new NativeItem("Female Ballas", "");
        uimenu.Add(femaleBallas);
        femaleBallas.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("G_F_Y_BALLAS_01");
        };

        NativeItem theBankManager = new NativeItem("Bank Manager", "");
        uimenu.Add(theBankManager);
        theBankManager.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_BANKMAN");
        };

        NativeItem bikerChick = new NativeItem("Female Biker Chick", "");
        uimenu.Add(bikerChick);
        bikerChick.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("U_F_Y_BIKERCHIC");
        };

        NativeItem Coroner = new NativeItem("Coroner", "");
        uimenu.Add(Coroner);
        Coroner.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_M_Y_AUTOPSY_01");
        };

        NativeItem femaleLifeguard = new NativeItem("Lifeguard (Female)", "");
        uimenu.Add(femaleLifeguard);
        femaleLifeguard.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_F_Y_BAYWATCH_01");
        };

        NativeItem FemaleBeachgoer = new NativeItem("Female Beachgoer", "");
        uimenu.Add(FemaleBeachgoer);
        FemaleBeachgoer.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("A_F_M_BEACH_01");
        };

        NativeItem InfernusStripper = new NativeItem("Stripper - Infernus", "");
        uimenu.Add(InfernusStripper);
        InfernusStripper.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_F_Y_STRIPPER_02");
        };

        NativeItem BusinessWoman = new NativeItem("Business Woman 1", "");
        uimenu.Add(BusinessWoman);
        BusinessWoman.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("A_F_Y_BUSINESS_01");
        };

        NativeItem ConstructionWorker = new NativeItem("Construction Worker 1", "");
        uimenu.Add(ConstructionWorker);
        ConstructionWorker.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_M_Y_CONSTRUCT_02");
        };

        NativeItem DrugDealer = new NativeItem("Drug Dealer", "");
        uimenu.Add(DrugDealer);
        DrugDealer.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_M_Y_DEALER_01");
        };

        NativeItem AirportWorker = new NativeItem("Airport Worker", "");
        uimenu.Add(AirportWorker);
        AirportWorker.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("S_M_Y_AIRWORKER");
        };

        NativeItem JanetBartender = new NativeItem("Janet", "A bar owner in Sandy Shores");
        uimenu.Add(JanetBartender);
        JanetBartender.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_JANET");
        };

        NativeItem KerryMcIntosh = new NativeItem("Kerry McIntosh", "");
        uimenu.Add(KerryMcIntosh);
        KerryMcIntosh.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_KERRYMCINTOSH");
        };

        NativeItem businessWoman = new NativeItem("Business Woman 1", "");
        uimenu.Add(businessWoman);
        businessWoman.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("A_F_Y_BUSINESS_01");
        };

        NativeItem businessWoman2 = new NativeItem("Business Woman 2", "");
        uimenu.Add(businessWoman2);
        businessWoman2.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("A_F_Y_BUSINESS_02");
        };

        NativeItem businessWoman3 = new NativeItem("Business Woman 3", "");
        uimenu.Add(businessWoman3);
        businessWoman3.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("A_F_Y_BUSINESS_03");
        };

        NativeItem shirtlessDude = new NativeItem("Shirtless Dude", "");
        uimenu.Add(shirtlessDude);
        shirtlessDude.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("U_M_Y_ABNER");
        };

        NativeItem footballFan = new NativeItem("Football Fan", "");
        uimenu.Add(footballFan);
        footballFan.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("a_m_m_afriamer_01");
        };

        NativeItem carMechanic = new NativeItem("Car Mechanic", "");
        uimenu.Add(carMechanic);
        carMechanic.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("s_m_m_autoshop_01");
        };

        NativeItem ClassyWoman = new NativeItem("Classy Woman", "");
        uimenu.Add(ClassyWoman);
        ClassyWoman.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("a_f_y_bevhills_01");
        };

        NativeItem FemaleLSPDWhiteCop = new NativeItem("LSPD Female Cop", "");
        uimenu.Add(FemaleLSPDWhiteCop);
        FemaleLSPDWhiteCop.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("s_f_y_cop_01");
        };

        NativeItem LSPDCop = new NativeItem("LSPD Male Cop", "");
        uimenu.Add(LSPDCop);
        LSPDCop.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("s_m_y_cop_01");
        };

        NativeItem deadCorpse = new NativeItem("Dead Corpse 1", "");
        uimenu.Add(deadCorpse);
        deadCorpse.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("u_f_m_corpse_01");
        };

        NativeItem militaryPed1 = new NativeItem("Military Guy 1", "");
        uimenu.Add(militaryPed1);
        militaryPed1.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("s_m_y_blackops_01");
        };

        NativeItem militaryPed2 = new NativeItem("Military Guy 2", "");
        uimenu.Add(militaryPed2);
        militaryPed2.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("s_m_y_blackops_02");
        };

        NativeItem militaryPed3 = new NativeItem("Military Guy 3", "");
        uimenu.Add(militaryPed3);
        militaryPed3.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("s_m_y_blackops_03");
        };

        NativeItem theBride = new NativeItem("Bride", "A sexy girl in a dress");
        uimenu.Add(theBride);
        theBride.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("ig_bride");
        };

        NativeItem caseyGruppe = new NativeItem("Casey", "Gruppe6 Security Driver");
        uimenu.Add(caseyGruppe);
        caseyGruppe.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("ig_casey");
        };

        NativeItem breakdancer = new NativeItem("Break Dancer", "A random dude from the hood");
        uimenu.Add(breakdancer);
        breakdancer.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("a_m_y_breakdance_01");
        };

        NativeItem burgershotDrugDealer = new NativeItem("Burger Shot Drug Dealer", "Jimmy DeSanta's Drug Dealer");
        uimenu.Add(burgershotDrugDealer);
        burgershotDrugDealer.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("u_m_y_burgerdrug_01");
        };

        NativeItem imaniDLC = new NativeItem("Imani", "[The Contract DLC]");
        uimenu.Add(imaniDLC);
        imaniDLC.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_IMANI");
        };

        NativeItem luchadora = new NativeItem("Luchadora", "[Los Santos Drug Wars DLC]");
        uimenu.Add(luchadora);
        luchadora.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_LUCHADORA");
        };

        NativeItem masonDugganDLC = new NativeItem("Mason Duggan", "[The Criminal Enterprises DLC]");
        uimenu.Add(masonDugganDLC);
        masonDugganDLC.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("IG_MASON_DUGGAN");
        };

        NativeItem chemicalWorker = new NativeItem("Chemical Worker", "He has covid");
        uimenu.Add(chemicalWorker);
        chemicalWorker.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("g_m_m_chemwork_01");
        };

        NativeItem clayPain = new NativeItem("Claypain", "A rapper from the hood");
        uimenu.Add(clayPain);
        clayPain.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("ig_claypain");
        };

        NativeItem stripperDancer = new NativeItem("Stripper", "Vanilla Unicorn Dancer");
        uimenu.Add(stripperDancer);
        stripperDancer.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("csb_stripper_01");
        };

        NativeItem femaleParkRanger = new NativeItem("Female Park Ranger", "Park ranger");
        uimenu.Add(femaleParkRanger);
        femaleParkRanger.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("s_f_y_ranger_01");
        };

        NativeItem casinoManager = new NativeItem("Agatha Baker", "");
        uimenu.Add(casinoManager);
        casinoManager.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("ig_agatha");
        };

        NativeItem casinoManagerCutscene = new NativeItem("Agatha Baker Cutscene", "");
        uimenu.Add(casinoManagerCutscene);
        casinoManagerCutscene.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("csb_agatha");
        };

        NativeItem georginaCheng = new NativeItem("Georgina Cheng", "Diamond Casino Heist DLC");
        uimenu.Add(georginaCheng);
        georginaCheng.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("ig_georginacheng");
        };

        NativeItem wendy = new NativeItem("Wendy", "Diamond Casino Heist DLC");
        uimenu.Add(wendy);
        wendy.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("ig_wendy");
        };

        NativeItem trevorPhilips = new NativeItem("Trevor Philips", "One of the main protagonists");
        uimenu.Add(trevorPhilips);
        trevorPhilips.Activated += (sender, args) =>
        {
            Game.Player.ChangeModel("player_two");
        };
    }
    //endregion

    //region // Vehicle Menu //
    public void VehicleMenu(NativeMenu menu)
    {
        NativeMenu uimenu = new NativeMenu("Civilian Vehicles", "View Civilian Vehicle Menu");
        _objectPool.Add(uimenu);
        menu.AddSubMenu(uimenu);

        void SpawnAndWarp(string model)
        {
            Vehicle vehicle = World.CreateVehicle(model, Game.Player.Character.Position);
            if (vehicle != null)
            {
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        }

        NativeItem tornado = new NativeItem("Tornado", "");
        uimenu.Add(tornado);
        tornado.Activated += (sender, args) => SpawnAndWarp("Tornado");

        NativeItem sovereign = new NativeItem("Sovereign", "");
        uimenu.Add(sovereign);
        sovereign.Activated += (sender, args) => SpawnAndWarp("Sovereign");

        NativeItem hustler = new NativeItem("Hustler", "");
        uimenu.Add(hustler);
        hustler.Activated += (sender, args) => SpawnAndWarp("Hustler");

        NativeItem bigRig = new NativeItem("Phantom", "");
        uimenu.Add(bigRig);
        bigRig.Activated += (sender, args) => SpawnAndWarp("Phantom");

        NativeItem beachBuggy = new NativeItem("Bifta", "");
        uimenu.Add(beachBuggy);
        beachBuggy.Activated += (sender, args) => SpawnAndWarp("Bifta");

        NativeItem punchBuggy = new NativeItem("Weevil", "");
        uimenu.Add(punchBuggy);
        punchBuggy.Activated += (sender, args) => SpawnAndWarp("Weevil");

        NativeItem bmxBike = new NativeItem("BMX (Bike)", "");
        uimenu.Add(bmxBike);
        bmxBike.Activated += (sender, args) => SpawnAndWarp("Bmx");

        NativeItem beachCruiser = new NativeItem("Beach Cruiser (Bike)", "");
        uimenu.Add(beachCruiser);
        beachCruiser.Activated += (sender, args) => SpawnAndWarp("Cruiser");

        NativeItem fixter = new NativeItem("Fixter (Bike)", "");
        uimenu.Add(fixter);
        fixter.Activated += (sender, args) => SpawnAndWarp("Fixter");

        NativeItem scorcherBike = new NativeItem("Scorcher (Bike)", "");
        uimenu.Add(scorcherBike);
        scorcherBike.Activated += (sender, args) => SpawnAndWarp("Scorcher");

        NativeItem triBike = new NativeItem("Tribike", "");
        uimenu.Add(triBike);
        triBike.Activated += (sender, args) => SpawnAndWarp("Tribike");

        NativeItem triBike2 = new NativeItem("Tribike 2", "");
        uimenu.Add(triBike2);
        triBike2.Activated += (sender, args) => SpawnAndWarp("Tribike2");

        NativeItem triBike3 = new NativeItem("Tribike 3", "");
        uimenu.Add(triBike3);
        triBike3.Activated += (sender, args) => SpawnAndWarp("Tribike3");

        NativeItem oppressor = new NativeItem("Oppressor", "");
        uimenu.Add(oppressor);
        oppressor.Activated += (sender, args) => SpawnAndWarp("Oppressor2");

        NativeItem bati = new NativeItem("Bati", "");
        uimenu.Add(bati);
        bati.Activated += (sender, args) => SpawnAndWarp("Bati");

        NativeItem faggio = new NativeItem("Faggio", "");
        uimenu.Add(faggio);
        faggio.Activated += (sender, args) => SpawnAndWarp("Faggio");

        NativeItem hermes = new NativeItem("Hermes", "");
        uimenu.Add(hermes);
        hermes.Activated += (sender, args) => SpawnAndWarp("Hermes");

        NativeItem duneBuggy = new NativeItem("Dune", "");
        uimenu.Add(duneBuggy);
        duneBuggy.Activated += (sender, args) => SpawnAndWarp("Dune");

        NativeItem outlaw = new NativeItem("Outlaw", "");
        uimenu.Add(outlaw);
        outlaw.Activated += (sender, args) => SpawnAndWarp("Outlaw");

        NativeItem benson = new NativeItem("Benson", "");
        uimenu.Add(benson);
        benson.Activated += (sender, args) => SpawnAndWarp("Benson");

        NativeItem mule1 = new NativeItem("Mule 1", "");
        uimenu.Add(mule1);
        mule1.Activated += (sender, args) => SpawnAndWarp("Mule");

        NativeItem dinghy5 = new NativeItem("Dinghy 5", "");
        uimenu.Add(dinghy5);
        dinghy5.Activated += (sender, args) => SpawnAndWarp("Dinghy5");

        NativeItem jetMax = new NativeItem("Jetmax", "");
        uimenu.Add(jetMax);
        jetMax.Activated += (sender, args) => SpawnAndWarp("Jetmax");

        NativeItem gunTruck = new NativeItem("Technical", "");
        uimenu.Add(gunTruck);
        gunTruck.Activated += (sender, args) => SpawnAndWarp("Technical");

        NativeItem gunTruck2 = new NativeItem("Technical 2", "");
        uimenu.Add(gunTruck2);
        gunTruck2.Activated += (sender, args) => SpawnAndWarp("Technical2");

        NativeItem dumpTruck = new NativeItem("Dump Truck", "");
        uimenu.Add(dumpTruck);
        dumpTruck.Activated += (sender, args) => SpawnAndWarp("Dump");

        NativeItem flatbedTow = new NativeItem("Flatbed", "");
        uimenu.Add(flatbedTow);
        flatbedTow.Activated += (sender, args) => SpawnAndWarp("Flatbed");

        NativeItem faggio3 = new NativeItem("Faggio 3", "");
        uimenu.Add(faggio3);
        faggio3.Activated += (sender, args) => SpawnAndWarp("Faggio3");

        NativeItem stryderBike = new NativeItem("Stryder", "");
        uimenu.Add(stryderBike);
        stryderBike.Activated += (sender, args) => SpawnAndWarp("Stryder");

        NativeItem terrorbyte = new NativeItem("Terrorbyte", "");
        uimenu.Add(terrorbyte);
        terrorbyte.Activated += (sender, args) => SpawnAndWarp("terbyte");

        NativeItem moneyTruck = new NativeItem("Stockade", "");
        uimenu.Add(moneyTruck);
        moneyTruck.Activated += (sender, args) => SpawnAndWarp("stockade");

        NativeItem asbo = new NativeItem("Asbo", "");
        uimenu.Add(asbo);
        asbo.Activated += (sender, args) => SpawnAndWarp("asbo");

        NativeItem blista = new NativeItem("Blista", "");
        uimenu.Add(blista);
        blista.Activated += (sender, args) => SpawnAndWarp("blista");

        NativeItem barrage = new NativeItem("Barrage", "");
        uimenu.Add(barrage);
        barrage.Activated += (sender, args) => SpawnAndWarp("barrage");

        NativeItem cargoBob = new NativeItem("Cargobob", "");
        uimenu.Add(cargoBob);
        cargoBob.Activated += (sender, args) => SpawnAndWarp("cargobob");

        NativeItem buzzard = new NativeItem("Buzzard", "");
        uimenu.Add(buzzard);
        buzzard.Activated += (sender, args) => SpawnAndWarp("buzzard");

        NativeItem minitank = new NativeItem("Minitank", "");
        uimenu.Add(minitank);
        minitank.Activated += (sender, args) => SpawnAndWarp("minitank");

        NativeItem seasparrowChopper = new NativeItem("Seasparrow 2", "");
        uimenu.Add(seasparrowChopper);
        seasparrowChopper.Activated += (sender, args) => SpawnAndWarp("seasparrow2");

        NativeItem bulldozer = new NativeItem("Bulldozer", "");
        uimenu.Add(bulldozer);
        bulldozer.Activated += (sender, args) => SpawnAndWarp("bulldozer");
    }
    //endregion

    //region // Animations Menu //
    public void MPAnimationsMenu(NativeMenu menu)
    {
        NativeMenu uimenu = new NativeMenu("Animations", "View Animations Menu");
        _objectPool.Add(uimenu);
        menu.AddSubMenu(uimenu);

        NativeItem StopAnimation = new NativeItem("Josh Chilling", "");
        uimenu.Add(StopAnimation);
        StopAnimation.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("rcmjosh1", "idle");
        };

        NativeItem dance1 = new NativeItem("Peace Sign", "");
        uimenu.Add(dance1);
        dance1.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_upperpeace_sign", "mp_player_int_peace_sign");
        };

        NativeItem GangSign1 = new NativeItem("Gang Sign 1", "");
        uimenu.Add(GangSign1);
        GangSign1.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_uppergang_sign_a", "mp_player_int_gang_sign_a");
        };

        NativeItem GangSign2 = new NativeItem("Gang Sign 2", "");
        uimenu.Add(GangSign2);
        GangSign2.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_uppergang_sign_b", "mp_player_int_gang_sign_b");
        };

        NativeItem RockSign = new NativeItem("Rock", "");
        uimenu.Add(RockSign);
        RockSign.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_upperrock", "mp_player_int_rock");
        };

        NativeItem HandSalute = new NativeItem("Hand Salute", "");
        uimenu.Add(HandSalute);
        HandSalute.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_uppersalute", "mp_player_int_salute");
        };

        NativeItem ChinBrush = new NativeItem("Chin Brush", "");
        uimenu.Add(ChinBrush);
        ChinBrush.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperchin_brush", "exit");
        };

        NativeItem TakePill = new NativeItem("Take Pill", "");
        uimenu.Add(TakePill);
        TakePill.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_suicide", "pill");
        };

        NativeItem upYours = new NativeItem("Up Yours", "");
        uimenu.Add(upYours);
        upYours.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_upperup_yours", "mp_player_int_up_yours_exit");
        };

        NativeItem wanking = new NativeItem("Wank", "");
        uimenu.Add(wanking);
        wanking.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_upperwank", "mp_player_int_wank_01");
        };

        NativeItem hostage = new NativeItem("Pistol to the Head", "");
        uimenu.Add(hostage);
        hostage.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_suicide", "pistol");
        };

        NativeItem flippingOff = new NativeItem("Flipping the Bird", "");
        uimenu.Add(flippingOff);
        flippingOff.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_intfinger", "mp_player_int_finger");
        };

        NativeItem loveBro = new NativeItem("Bro Love", "");
        uimenu.Add(loveBro);
        loveBro.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_upperbro_love", "mp_player_int_bro_love");
        };

        NativeItem headNod = new NativeItem("Head Nod", "");
        uimenu.Add(headNod);
        headNod.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_upper_nod", "mp_player_int_nod_no");
        };

        NativeItem docking = new NativeItem("Docking", "");
        uimenu.Add(docking);
        docking.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperdock", "exit_fp");
        };

        NativeItem grabbingtheDick = new NativeItem("Grab Deez Nuts", "");
        uimenu.Add(grabbingtheDick);
        grabbingtheDick.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_uppergrab_crotch", "mp_player_int_grab_crotch");
        };

        NativeItem facepalm = new NativeItem("Face Palm", "");
        uimenu.Add(facepalm);
        facepalm.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperface_palm", "enter_fp");
        };

        NativeItem diggingForCheese = new NativeItem("Digging for Cheese", "");
        uimenu.Add(diggingForCheese);
        diggingForCheese.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_player_int_upperarse_pick", "mp_player_int_arse_pick");
        };

        NativeItem mouthYapping = new NativeItem("Mouth Yapping", "");
        uimenu.Add(mouthYapping);
        mouthYapping.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_facial", "mic_chatter");
        };

        NativeItem leaning = new NativeItem("Leaning", "");
        uimenu.Add(leaning);
        leaning.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_cp_welcome_tutleaning", "idle_a");
        };

        NativeItem airGuitar = new NativeItem("Air Guitar", "");
        uimenu.Add(airGuitar);
        airGuitar.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperair_guitar", "idle_a_fp");
        };

        NativeItem crunchingKnuckles = new NativeItem("Crunching Knuckles", "");
        uimenu.Add(crunchingKnuckles);
        crunchingKnuckles.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperknuckle_crunch", "idle_a");
        };

        NativeItem nosePicking = new NativeItem("Nose Picking", "");
        uimenu.Add(nosePicking);
        nosePicking.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intuppernose_pick", "enter");
        };

        NativeItem djing = new NativeItem("DJ", "");
        uimenu.Add(djing);
        djing.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperdj", "idle_a");
        };

        NativeItem BeQuiet = new NativeItem("Be Quiet", "");
        uimenu.Add(BeQuiet);
        BeQuiet.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intuppershush", "enter");
        };

        NativeItem thumbsUp = new NativeItem("Thumbs Up", "");
        uimenu.Add(thumbsUp);
        thumbsUp.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperthumbs_up", "enter");
        };

        NativeItem slowclapping = new NativeItem("Slow Clapping", "");
        uimenu.Add(slowclapping);
        slowclapping.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperslow_clap", "idle_a");
        };

        NativeItem ISurrender = new NativeItem("Surrendering", "");
        uimenu.Add(ISurrender);
        ISurrender.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intuppersurrender", "enter");
        };

        NativeItem MakeItRain = new NativeItem("Make It Rain", "");
        uimenu.Add(MakeItRain);
        MakeItRain.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperraining_cash", "idle_a");
        };

        NativeItem yourLoco = new NativeItem("Your Loco", "");
        uimenu.Add(yourLoco);
        yourLoco.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperyou_loco", "idle_a");
        };

        NativeItem Waving = new NativeItem("Waving", "");
        uimenu.Add(Waving);
        Waving.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperwave", "idle_a");
        };

        NativeItem Disco = new NativeItem("70s Disco", "");
        uimenu.Add(Disco);
        Disco.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperuncle_disco", "idle_a");
        };

        NativeItem pluggingEars = new NativeItem("Plugging Ears", "");
        uimenu.Add(pluggingEars);
        pluggingEars.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperthumb_on_ears", "idle_a");
        };

        NativeItem amandaIdle = new NativeItem("Amanda Sitting Idle", "");
        uimenu.Add(amandaIdle);
        amandaIdle.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("timetable@reunited@ig_10", "base_amanda");
        };

        NativeItem meditateIdle = new NativeItem("Meditate", "");
        uimenu.Add(meditateIdle);
        meditateIdle.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("rcmcollect_paperleadinout@", "meditiate_idle");
        };

        NativeItem twerking = new NativeItem("Twerk", "");
        uimenu.Add(twerking);
        twerking.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("switch@trevor@mocks_lapdance", "001443_01_trvs_28_idle_stripper");
        };

        NativeItem PrivatedanceIdle = new NativeItem("Private Dance Idle", "");
        uimenu.Add(PrivatedanceIdle);
        PrivatedanceIdle.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mini@strip_club@private_dance@idle", "priv_dance_idle");
        };

        NativeItem lapdance2 = new NativeItem("Lap Dance 2", "");
        uimenu.Add(lapdance2);
        lapdance2.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mini@strip_club@lap_dance_2g@ld_2g_p1", "ld_2g_p1_s2");
        };

        NativeItem BBQanim = new NativeItem("BBQ", "");
        uimenu.Add(BBQanim);
        BBQanim.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("amb@prop_human_bbq@male@idle_a", "idle_b");
        };

        NativeItem trevorPuking = new NativeItem("Trevor Puking", "");
        uimenu.Add(trevorPuking);
        trevorPuking.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("missheistpaletoscore1leadinout", "trv_puking_leadout");
        };

        NativeItem callChop = new NativeItem("Call Chop", "");
        uimenu.Add(callChop);
        callChop.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("missfra0_chop_find", "call_chop_l");
        };

        NativeItem carmeetCheckoutCar = new NativeItem("Checking Out Car Carmeet", "");
        uimenu.Add(carmeetCheckoutCar);
        carmeetCheckoutCar.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@amb@carmeet@checkout_car@", "female_c_idle_d");
        };

        NativeItem lapDanceStripper = new NativeItem("Lap Dance 3", "");
        uimenu.Add(lapDanceStripper);
        lapDanceStripper.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mp_am_stripper", "lap_dance_girl");
        };

        NativeItem lapDanceStripper2 = new NativeItem("Lap Dance 4", "");
        uimenu.Add(lapDanceStripper2);
        lapDanceStripper2.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mini@strip_club@private_dance@part1", "priv_dance_p1");
        };

        NativeItem yachtLapDance = new NativeItem("Yacht Lap Dance", "");
        uimenu.Add(yachtLapDance);
        yachtLapDance.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("oddjobs@assassinate@multi@yachttarget@lapdance", "yacht_ld_f");
        };

        NativeItem bitchSlap = new NativeItem("Bitch Slap", "");
        uimenu.Add(bitchSlap);
        bitchSlap.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("melee@unarmed@streamed_variations", "plyr_takedown_front_slap");
        };

        NativeItem headButt = new NativeItem("Head Butt", "");
        uimenu.Add(headButt);
        headButt.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("melee@unarmed@streamed_variations", "plyr_takedown_front_headbutt");
        };

        NativeItem sassyMiddleFinger = new NativeItem("Sassy Middle Finger", "");
        uimenu.Add(sassyMiddleFinger);
        sassyMiddleFinger.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@mp_player_intcelebrationfemale@finger", "finger");
        };

        NativeItem gettingDicked = new NativeItem("Getting Dicked (NSFW)", "");
        uimenu.Add(gettingDicked);
        gettingDicked.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("rcmpaparazzo_2", "shag_action_poppy");
        };

        NativeItem Buttwag = new NativeItem("Buttwag", "");
        uimenu.Add(Buttwag);
        Buttwag.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("special_ped@mountain_dancer@monologue_3@monologue_3a", "mnt_dnc_buttwag");
        };

        NativeItem smokingFemale = new NativeItem("Smoking (Female)", "");
        uimenu.Add(smokingFemale);
        smokingFemale.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("amb@world_human_smoking@female@idle_a", "idle_b");
        };

        NativeItem sillyDance1 = new NativeItem("Silly Dance 1", "");
        uimenu.Add(sillyDance1);
        sillyDance1.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("anim@amb@nightclub@lazlow@hi_dancefloor@", "crowddance_hi_11_handup_laz");
        };

        NativeItem situps = new NativeItem("Situps", "");
        uimenu.Add(situps);
        situps.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("amb@world_human_sit_ups@male@idle_a", "idle_a");
        };

        NativeItem rejectIdle = new NativeItem("Rejct Idle", "");
        uimenu.Add(rejectIdle);
        rejectIdle.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("mini@hookers_sp", "idle_reject");
        };

        NativeItem traceyDance = new NativeItem("The Tracey Dance", "");
        uimenu.Add(traceyDance);
        traceyDance.Activated += (sender, args) =>
        {
            Game.Player.Character.Task.PlayAnimation("timetable@tracy@ig_5@idle_a", "idle_c");
        };
    }
    //endregion

    //region // Weapon Menu //
    public void WeaponMenu(NativeMenu menu)
    {
        NativeMenu weapons = new NativeMenu("Weapons", "View Weapon Menu");
        _objectPool.Add(weapons);
        menu.AddSubMenu(weapons);

        NativeItem newweapons = new NativeItem("Give Weapons", "");
        weapons.Add(newweapons);
        newweapons.Activated += (sender, args) =>
        {
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_GOLFCLUB"), 1, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_COMBATPISTOL"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_PUMPSHOTGUN"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_TACTICALRIFLE"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_COMBATMG"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_RPG"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_GRENADELAUNCHER"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_MINIGUN"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_RAILGUN"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_STICKYBOMB"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_DOUBLEACTION"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_FIREEXTINGUISHER"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SNIPERRIFLE"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_PISTOL"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_STUNGUN"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SNSPISTOL"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_RAYPISTOL"), 9999, false, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SWITCHBLADE"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SMG"), 9999, false, true);
        };

        NativeItem dropWeapon = new NativeItem("Drop Weapon", "");
        weapons.Add(dropWeapon);
        dropWeapon.Activated += (sender, args) =>
        {
            Game.Player.Character.Weapons.Drop();
        };
    }
    //endregion

    //region // Options Menu //
    public void OptionsMenu(NativeMenu menu)
    {
        NativeMenu uimenu = new NativeMenu("Options", "View Options Menu");
        _objectPool.Add(uimenu);
        menu.AddSubMenu(uimenu);

        NativeItem removeWeapons = new NativeItem("Remove Weapons", "");
        uimenu.Add(removeWeapons);
        removeWeapons.Activated += (sender, args) =>
        {
            Game.Player.Character.Weapons.RemoveAll();
            BigMessageThread.MessageInstance.ShowSimpleShard("SUCCESS", "Weapons Removed successfully! :-)");
        };

        NativeItem giveArmor = new NativeItem("Give Armor", "");
        uimenu.Add(giveArmor);
        giveArmor.Activated += (sender, args) =>
        {
            Game.Player.Character.Armor = 100;
        };

        NativeItem cleanBlood = new NativeItem("Clear Blood", "");
        uimenu.Add(cleanBlood);
        cleanBlood.Activated += (sender, args) =>
        {
            Game.Player.Character.ClearBloodDamage();
        };

        NativeItem rechargeSA = new NativeItem("Refill Special Ability", "");
        uimenu.Add(rechargeSA);
        rechargeSA.Activated += (sender, args) =>
        {
            Game.Player.RefillSpecialAbility();
        };

        NativeItem playerSuicide = new NativeItem("Kill Yourself", "");
        uimenu.Add(playerSuicide);
        playerSuicide.Activated += (sender, args) =>
        {
            Game.Player.Character.Kill();
        };

        NativeItem godMode = new NativeItem("God Mode", "");
        uimenu.Add(godMode);
        godMode.Activated += (sender, args) =>
        {
            Game.Player.Character.IsInvincible = true;
        };

        NativeItem godModeRemoval = new NativeItem("Remove God Mode", "");
        uimenu.Add(godModeRemoval);
        godModeRemoval.Activated += (sender, args) =>
        {
            Game.Player.Character.IsInvincible = false;
        };

        NativeItem tenGrand = new NativeItem("Give $10,000", "");
        uimenu.Add(tenGrand);
        tenGrand.Activated += (sender, args) =>
        {
            Game.Player.Money += 10000;
            BigMessageThread.MessageInstance.ShowSimpleShard("Money", "You have been given $10,000");
        };

        NativeItem millyMilly = new NativeItem("Give $1,000,000", "");
        uimenu.Add(millyMilly);
        millyMilly.Activated += (sender, args) =>
        {
            Game.Player.Money += 1000000;
            BigMessageThread.MessageInstance.ShowSimpleShard("Money", "You have been given $1,000,000");
        };

        NativeItem twentyMilly = new NativeItem("Give $20,000,000", "");
        uimenu.Add(twentyMilly);
        twentyMilly.Activated += (sender, args) =>
        {
            Game.Player.Money += 20000000;
            BigMessageThread.MessageInstance.ShowSimpleShard("Money", "You have been given $20,000,000");
        };

        NativeItem stopMusic = new NativeItem("Stop Music", "");
        uimenu.Add(stopMusic);
        stopMusic.Activated += (sender, args) =>
        {
            Game.RadioStation = RadioStation.RadioOff;
            BigMessageThread.MessageInstance.ShowSimpleShard("Music", "Stopped");
        };

        // --- Squad Management ---
        var squadMenu = new NativeMenu("Squad", "Spawn and manage companions");
        _objectPool.Add(squadMenu);
        uimenu.AddSubMenu(squadMenu);

        var spawnComp = new NativeItem("Spawn Companion (Default)", "Spawns a default companion");
        squadMenu.Add(spawnComp);
        spawnComp.Activated += (s, a) => SpawnCompanion("a_m_m_skater_01");

        var dismissSquad = new NativeItem("Dismiss Squad", "Remove all companions");
        squadMenu.Add(dismissSquad);
        dismissSquad.Activated += (s, a) => DismissSquad();

        var followOrder = new NativeItem("Order: Follow", "Order squad to follow you");
        squadMenu.Add(followOrder);
        followOrder.Activated += (s, a) => GiveSquadFollow();

        var guardOrder = new NativeItem("Order: Guard", "Order squad to guard position");
        squadMenu.Add(guardOrder);
        guardOrder.Activated += (s, a) => GiveSquadGuard();

        var attackOrder = new NativeItem("Order: Attack Nearest", "Order squad to attack nearest enemy");
        squadMenu.Add(attackOrder);
        attackOrder.Activated += (s, a) => GiveSquadAttackNearest();

        var savePreset = new NativeItem("Save Squad Preset", "Save the current squad as a preset");
        squadMenu.Add(savePreset);
        savePreset.Activated += (s, a) => SaveCurrentSquadPreset();

        var presetsMenu = new NativeMenu("Squad Presets", "Load or delete saved presets");
        _objectPool.Add(presetsMenu);
        squadMenu.AddSubMenu(presetsMenu);
        BuildSquadPresetsMenu(presetsMenu);

        // --- Loadouts ---
        var loadoutMenu = new NativeMenu("Loadouts", "Manage weapon loadouts");
        _objectPool.Add(loadoutMenu);
        uimenu.AddSubMenu(loadoutMenu);

        var applyLoadout1 = new NativeItem("Apply Loadout 1", "Apply saved loadout 1");
        loadoutMenu.Add(applyLoadout1);
        applyLoadout1.Activated += (s, a) =>
        {
            string csv = config.GetValue(LoadoutsSection, "Loadout1", "WEAPON_COMBATPISTOL:9999");
            ApplyLoadout(csv);
            BigMessageThread.MessageInstance.ShowSimpleShard("Loadouts", "Loadout 1 applied");
        };
    }
    //endregion

    //region //Radio Station Menu //
    public void RadioStationMenu(NativeMenu menu)
    {
        NativeMenu uimenu = new NativeMenu("Radio Options", "View Radio Options Menu");
        _objectPool.Add(uimenu);
        menu.AddSubMenu(uimenu);

        void SetRadio(RadioStation station)
        {
            Game.RadioStation = station;
        }

        NativeItem radioLosSantosRock = new NativeItem("Los Santos Rock", "");
        uimenu.Add(radioLosSantosRock);
        radioLosSantosRock.Activated += (s, a) => SetRadio(RadioStation.LosSantosRockRadio);

        NativeItem blaineCountyRadio = new NativeItem("Blaine County Radio", "");
        uimenu.Add(blaineCountyRadio);
        blaineCountyRadio.Activated += (s, a) => SetRadio(RadioStation.BlaineCountyRadio);

        NativeItem rebelRadio = new NativeItem("Rebel Radio", "");
        uimenu.Add(rebelRadio);
        rebelRadio.Activated += (s, a) => SetRadio(RadioStation.RebelRadio);

        NativeItem westCoastRadio = new NativeItem("West Coast Classics", "");
        uimenu.Add(westCoastRadio);
        westCoastRadio.Activated += (s, a) => SetRadio(RadioStation.WestCoastClassics);

        NativeItem westCoastTalkRadio = new NativeItem("West Coast Talk Show", "");
        uimenu.Add(westCoastTalkRadio);
        westCoastTalkRadio.Activated += (s, a) => SetRadio(RadioStation.WestCoastTalkRadio);

        NativeItem radioEastLosFM = new NativeItem("East Los FM", "");
        uimenu.Add(radioEastLosFM);
        radioEastLosFM.Activated += (s, a) => SetRadio(RadioStation.EastLosFM);

        NativeItem selfRadio = new NativeItem("Self Radio", "");
        uimenu.Add(selfRadio);
        selfRadio.Activated += (s, a) => SetRadio(RadioStation.SelfRadio);

        NativeItem losSantosBlonded = new NativeItem("Blonded Los Santos", "");
        uimenu.Add(losSantosBlonded);
        losSantosBlonded.Activated += (s, a) => SetRadio(RadioStation.BlondedLosSantos);

        NativeItem xChannel = new NativeItem("Channel X", "");
        uimenu.Add(xChannel);
        xChannel.Activated += (s, a) => SetRadio(RadioStation.ChannelX);

        NativeItem flyloFM = new NativeItem("FlyloFM", "");
        uimenu.Add(flyloFM);
        flyloFM.Activated += (s, a) => SetRadio(RadioStation.FlyloFM);

        NativeItem iFruitRadio = new NativeItem("iFruit Radio", "");
        uimenu.Add(iFruitRadio);
        iFruitRadio.Activated += (s, a) => SetRadio(RadioStation.iFruitRadio);

        NativeItem cultFM = new NativeItem("KultFM", "");
        uimenu.Add(cultFM);
        cultFM.Activated += (s, a) => SetRadio(RadioStation.KultFM);

        NativeItem infoWarsRadio = new NativeItem("Los Santos Underground Radio", "");
        uimenu.Add(infoWarsRadio);
        infoWarsRadio.Activated += (s, a) => SetRadio(RadioStation.LosSantosUndergroundRadio);

        NativeItem theMediaPlayer = new NativeItem("Media Player", "");
        uimenu.Add(theMediaPlayer);
        theMediaPlayer.Activated += (s, a) => SetRadio(RadioStation.MediaPlayer);

        NativeItem motoMamiRadio = new NativeItem("Motomami Los Santos", "");
        uimenu.Add(motoMamiRadio);
        motoMamiRadio.Activated += (s, a) => SetRadio(RadioStation.MotomamiLosSantos);

        NativeItem theMusicLocker = new NativeItem("Music Locker", "");
        uimenu.Add(theMusicLocker);
        theMusicLocker.Activated += (s, a) => SetRadio(RadioStation.MusicLocker);

        NativeItem nonstopRadio = new NativeItem("NonStop Pop FM", "");
        uimenu.Add(nonstopRadio);
        nonstopRadio.Activated += (s, a) => SetRadio(RadioStation.NonStopPopFM);

        NativeItem lossantosRadio = new NativeItem("Los Santos Radio", "");
        uimenu.Add(lossantosRadio);
        lossantosRadio.Activated += (s, a) => SetRadio(RadioStation.RadioLosSantos);

        NativeItem mirrorParkRadio = new NativeItem("Mirror Park Radio", "");
        uimenu.Add(mirrorParkRadio);
        mirrorParkRadio.Activated += (s, a) => SetRadio(RadioStation.RadioMirrorPark);

        NativeItem soulwaxFM = new NativeItem("Soulwax FM", "");
        uimenu.Add(soulwaxFM);
        soulwaxFM.Activated += (s, a) => SetRadio(RadioStation.SoulwaxFM);

        NativeItem spaceRadio = new NativeItem("Space Radio", "");
        uimenu.Add(spaceRadio);
        spaceRadio.Activated += (s, a) => SetRadio(RadioStation.Space);

        NativeItem slippingLosSantos = new NativeItem("Still Slipping Los Santos Radio", "");
        uimenu.Add(slippingLosSantos);
        slippingLosSantos.Activated += (s, a) => SetRadio(RadioStation.StillSlippingLosSantos);

        NativeItem blueArkRadio = new NativeItem("The Blue Ark", "");
        uimenu.Add(blueArkRadio);
        blueArkRadio.Activated += (s, a) => SetRadio(RadioStation.TheBlueArk);

        NativeItem theLabRadio = new NativeItem("The Lab", "");
        uimenu.Add(theLabRadio);
        theLabRadio.Activated += (s, a) => SetRadio(RadioStation.TheLab);

        NativeItem lowdownRadio = new NativeItem("The Lowdown", "");
        uimenu.Add(lowdownRadio);
        lowdownRadio.Activated += (s, a) => SetRadio(RadioStation.TheLowdown);

        NativeItem vinewoodRadio = new NativeItem("Vinewood Boulevard Radio", "");
        uimenu.Add(vinewoodRadio);
        vinewoodRadio.Activated += (s, a) => SetRadio(RadioStation.VinewoodBoulevardRadio);

        NativeItem worldWideFM = new NativeItem("World Wide FM", "");
        uimenu.Add(worldWideFM);
        worldWideFM.Activated += (s, a) => SetRadio(RadioStation.WorldWideFM);
    }
    //endregion

    //region // Animal Menu //
    public void AnimalMenu(NativeMenu menu)
    {
        NativeMenu uimenu = new NativeMenu("Animals", "View Animal Menu");
        _objectPool.Add(uimenu);
        menu.AddSubMenu(uimenu);

        void ChangeModel(string model) => Game.Player.ChangeModel(model);

        NativeItem pig = new NativeItem("Pig", "");
        uimenu.Add(pig);
        pig.Activated += (s, a) => ChangeModel("A_C_PIG");

        NativeItem poodle = new NativeItem("Poodle", "");
        uimenu.Add(poodle);
        poodle.Activated += (s, a) => ChangeModel("A_C_POODLE");

        NativeItem bugsbunny = new NativeItem("Rabbit", "");
        uimenu.Add(bugsbunny);
        bugsbunny.Activated += (s, a) => ChangeModel("A_C_RABBIT_01");

        NativeItem wildHog = new NativeItem("Boar", "");
        uimenu.Add(wildHog);
        wildHog.Activated += (s, a) => ChangeModel("A_C_BOAR");

        NativeItem pussyCat = new NativeItem("Pussy Cat", "");
        uimenu.Add(pussyCat);
        pussyCat.Activated += (s, a) => ChangeModel("A_C_CAT_01");

        NativeItem chickenHawk = new NativeItem("Chicken Hawk", "");
        uimenu.Add(chickenHawk);
        chickenHawk.Activated += (s, a) => ChangeModel("A_C_CHICKENHAWK");

        NativeItem monkey = new NativeItem("Monkey", "");
        uimenu.Add(monkey);
        monkey.Activated += (s, a) => ChangeModel("A_C_CHIMP");

        NativeItem seagull = new NativeItem("Seagull", "");
        uimenu.Add(seagull);
        seagull.Activated += (s, a) => ChangeModel("A_C_CORMORANT");

        NativeItem cow = new NativeItem("Cow", "");
        uimenu.Add(cow);
        cow.Activated += (s, a) => ChangeModel("A_C_COW");

        NativeItem coyote = new NativeItem("Coyote", "");
        uimenu.Add(coyote);
        coyote.Activated += (s, a) => ChangeModel("A_C_COYOTE");

        NativeItem crow = new NativeItem("Crow", "");
        uimenu.Add(crow);
        crow.Activated += (s, a) => ChangeModel("A_C_CROW");

        NativeItem deer = new NativeItem("Deer", "");
        uimenu.Add(deer);
        deer.Activated += (s, a) => ChangeModel("A_C_DEER");

        NativeItem dolphin = new NativeItem("Dolphin", "");
        uimenu.Add(dolphin);
        dolphin.Activated += (s, a) => ChangeModel("A_C_DOLPHIN");

        NativeItem fish = new NativeItem("Fish", "");
        uimenu.Add(fish);
        fish.Activated += (s, a) => ChangeModel("A_C_FISH");

        NativeItem hammerShark = new NativeItem("Hammer Shark", "");
        uimenu.Add(hammerShark);
        hammerShark.Activated += (s, a) => ChangeModel("A_C_SHARKHAMMER");

        NativeItem chickenHen = new NativeItem("Hen", "");
        uimenu.Add(chickenHen);
        chickenHen.Activated += (s, a) => ChangeModel("A_C_HEN");

        NativeItem humbackWhale = new NativeItem("Humpback Whale", "");
        uimenu.Add(humbackWhale);
        humbackWhale.Activated += (s, a) => ChangeModel("A_C_HUMPBACK");

        NativeItem shamuWhale = new NativeItem("Killer Whale", "");
        uimenu.Add(shamuWhale);
        shamuWhale.Activated += (s, a) => ChangeModel("A_C_KILLERWHALE");

        NativeItem pigeon = new NativeItem("Pigeon", "");
        uimenu.Add(pigeon);
        pigeon.Activated += (s, a) => ChangeModel("A_C_PIGEON");

        NativeItem pugDog = new NativeItem("Pug", "");
        uimenu.Add(pugDog);
        pugDog.Activated += (s, a) => ChangeModel("A_C_PUG");
    }
    //endregion

    //region // Prop Weapons //
    public void PropWeaponMenu(NativeMenu menu)
    {
        NativeMenu props = new NativeMenu("Prop Weapons", "View Prop Weapons Menu");
        _objectPool.Add(props);
        menu.AddSubMenu(props);

        NativeItem newprops = new NativeItem("Give Props", "");
        props.Add(newprops);
        newprops.Activated += (sender, args) =>
        {
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_BAT"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_CROWBAR"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_GOLFCLUB"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_BOTTLE"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_DAGGER"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_FLASHLIGHT"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_HAMMER"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_HATCHET"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_KNIFE"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_MACHETE"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SWITCHBLADE"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_CANDYCANE"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SNOWBALL"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_BALL"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_ACIDPACKAGE"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_PETROLCAN"), 9999, true, true);
            Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_FIREEXTINGUISHER"), 9999, true, true);
        };
    }
    //endregion

    //region // Credits Menu //
    public void Credits(NativeMenu menu)
    {
        NativeMenu uimenu = new NativeMenu("Credits", "View Credits");
        _objectPool.Add(uimenu);
        menu.AddSubMenu(uimenu);
        NativeItem credit1 = new NativeItem("Mod by Jon Jon Games");
        uimenu.Add(credit1);
        NativeItem credit2 = new NativeItem("GTA5-Mods Page", "https://www.gta5-mods.com/scripts/simple-ped-menu");
        uimenu.Add(credit2);
    }
    //endregion

    //region // Menu Setup //
    public SimplePedMenu()
    {
        _objectPool = new ObjectPool();

        _mainMenu = new NativeMenu("~o~Simple ~w~Ped ~g~Menu", "Mod by Jon Jon Games v3.0");
        _objectPool.Add(_mainMenu);

        // Ensure INI exists and load config so favorites can use it
        string iniPath = Path.Combine("scripts", "SimplePedMenu.ini");
        try
        {
            string iniDir = Path.GetDirectoryName(iniPath);
            if (!string.IsNullOrEmpty(iniDir) && !Directory.Exists(iniDir))
            {
                Directory.CreateDirectory(iniDir);
            }

            if (!File.Exists(iniPath))
            {
                string defaultIni =
                    "[Options]\r\n" +
                    "OpenMenu=F9\r\n" +
                    "Language=en\r\n" +
                    "HotkeysEnabled=true\r\n\r\n" +
                    "[FavoritesPeds]\r\n" +
                    "Models=\r\n" +
                    "Hotkeys=1=,2=,3=,4=,5=\r\n\r\n" +
                    "[FavoritesVehicles]\r\n" +
                    "Models=\r\n" +
                    "Hotkeys=1=,2=,3=,4=,5=\r\n\r\n" +
                    "[Squad]\r\n" +
                    "CompanionCount=0\r\n" +
                    "CompanionModels=\r\n\r\n" +
                    "[Loadouts]\r\n" +
                    "Loadout1=WEAPON_COMBATPISTOL:9999\r\r\n" +
                    "[Cheats]\r\r\n" +
                    "InfiniteHealth=false\r\n" +
                    "InfiniteAmmo=false\r\n" +
                    "NoWanted=false\r\n";

                File.WriteAllText(iniPath, defaultIni);
            }
        }
        catch (Exception)
        {
            // If creating the file fails, fall back to loading default settings location used previously
            iniPath = "//scripts//SimplePedMenu.ini";
        }

        config = ScriptSettings.Load(iniPath);
        // Auto-migrate INI schema: ensure keys exist
        EnsureIniSchema(config);

        OpenMenu = config.GetValue<Keys>("Options", "OpenMenu", Keys.F9);

        LoadFavorites();

        PlayerModelMenu(_mainMenu);
        VehicleMenu(_mainMenu);
        WeaponMenu(_mainMenu);
        AnimalMenu(_mainMenu);
        RadioStationMenu(_mainMenu);
        OptionsMenu(_mainMenu);
        MPAnimationsMenu(_mainMenu);
        PropWeaponMenu(_mainMenu);
        FavoritesMenu(_mainMenu);
        Credits(_mainMenu);

        Tick += (o, e) =>
        {
            _objectPool.Process();
            EnforceCheats();
        };

        KeyDown += (o, e) =>
        {
            // Handle OpenMenu toggle
            if (e.KeyCode == OpenMenu && !_objectPool.AreAnyVisible)
            {
                _mainMenu.Visible = !_mainMenu.Visible;
                return;
            }

            // Hotkeys for favorites
            HandleHotkeys(e.KeyCode);
        };
    }
    //endregion
}
