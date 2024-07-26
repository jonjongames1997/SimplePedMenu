// Native UI Menu Template 3.0 - Abel Software
// You must download and use Scripthook V Dot Net Reference and NativeUI Reference (LINKS AT BOTTOM OF THE TEMPLATE)
using GTA;
using NativeUI;
using System.Windows.Forms;
using System;
using GTA.Native;

public class SimplePedMenu : Script
{
    private Ped playerPed = Game.Player.Character;
    private Player player = Game.Player;
    private MenuPool _menuPool;
    private ScriptSettings config;
    private Keys OpenMenu;

    //Now, we will add your sub menu, which in this case, will be player menu to change your player model.
    public void PlayerModelMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Peds");
        for (int i = 0; i < 1; i++)
        {
        }
        UIMenuItem femaleTopless = new UIMenuItem("Female Topless 1", "");
        uimenu.AddItem(femaleTopless);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == femaleTopless;
            if (flag)
            {
                Game.Player.ChangeModel("A_F_Y_TOPLESS_01");
            }
        };
        UIMenuItem tonyaHooker = new UIMenuItem("Tonya", "");
        uimenu.AddItem(tonyaHooker);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == tonyaHooker;
            if (flag)
            {
                Game.Player.ChangeModel("IG_TONYA");
            }
        };
        UIMenuItem karenDaniels = new UIMenuItem("Karen Daniels", "");
        uimenu.AddItem(karenDaniels);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == karenDaniels;
            if (flag)
            {
                Game.Player.ChangeModel("IG_MICHELLE");
            }
        };
        UIMenuItem tourist = new UIMenuItem("Female Tourist 1", "");
        uimenu.AddItem(tourist);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == tourist;
            if (flag)
            {
                Game.Player.ChangeModel("A_F_Y_TOURIST_01");
            }
        };
        UIMenuItem vagosGirl01 = new UIMenuItem("Female Vagos 1", "");
        uimenu.AddItem(vagosGirl01);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == vagosGirl01;
            if (flag)
            {
                Game.Player.ChangeModel("G_F_Y_VAGOS_01");
            }
        };
        UIMenuItem ashleyCrackhead = new UIMenuItem("Ashley", "");
        uimenu.AddItem(ashleyCrackhead);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == ashleyCrackhead;
            if (flag)
            {
                Game.Player.ChangeModel("IG_ASHLEY");
            }
        };
        UIMenuItem grandpa = new UIMenuItem("Grandpa", "");
        uimenu.AddItem(grandpa);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == grandpa;
            if (flag)
            {
                Game.Player.ChangeModel("A_M_O_GENSTREET_01");
            }
        };
        UIMenuItem sexyPoppy = new UIMenuItem("Poppy Mitchell", "");
        uimenu.AddItem(sexyPoppy);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sexyPoppy;
            if (flag)
            {
                Game.Player.ChangeModel("U_F_Y_POPPYMICH");
            }
        };
        UIMenuItem sexyMaryAnn = new UIMenuItem("Mary Ann", "");
        uimenu.AddItem(sexyMaryAnn);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sexyMaryAnn;
            if (flag)
            {
                Game.Player.ChangeModel("IG_MARYANN");
            }
        };
        UIMenuItem jewelstoreLady = new UIMenuItem("Jewel Store Lady", "");
        uimenu.AddItem(jewelstoreLady);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == jewelstoreLady;
            if (flag)
            {
                Game.Player.ChangeModel("IG_JEWELASS");
            }
        };
        UIMenuItem sexyHooker01 = new UIMenuItem("Hooker 1", "");
        uimenu.AddItem(sexyHooker01);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sexyHooker01;
            if (flag)
            {
                Game.Player.ChangeModel("S_F_Y_HOOKER_01");
            }
        };
        UIMenuItem sexyHooker02 = new UIMenuItem("Hooker 2", "");
        uimenu.AddItem(sexyHooker02);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sexyHooker02;
            if (flag)
            {
                Game.Player.ChangeModel("S_F_Y_HOOKER_02");
            }
        };
        UIMenuItem sexyHooker03 = new UIMenuItem("Hooker 3", "");
        uimenu.AddItem(sexyHooker03);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sexyHooker03;
            if (flag)
            {
                Game.Player.ChangeModel("S_F_Y_HOOKER_03");
            }
        };
        UIMenuItem abigail = new UIMenuItem("Abigail", "");
        uimenu.AddItem(abigail);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == abigail;
            if (flag)
            {
                Game.Player.ChangeModel("IG_ABIGAIL");
            }
        };
        UIMenuItem cultguy01 = new UIMenuItem("Male Cult 1", "");
        uimenu.AddItem(cultguy01);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == cultguy01;
            if (flag)
            {
                Game.Player.ChangeModel("A_M_M_ACULT_01");
            }
        };
        UIMenuItem cultguy02 = new UIMenuItem("Male Cult 2", "");
        uimenu.AddItem(cultguy02);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == cultguy02;
            if (flag)
            {
                Game.Player.ChangeModel("A_M_O_ACULT_01");
            }
        };
        UIMenuItem cultguy03 = new UIMenuItem("Male Cult 3", "");
        uimenu.AddItem(cultguy03);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == cultguy03;
            if (flag)
            {
                Game.Player.ChangeModel("A_M_Y_ACULT_01");
            }
        };
        UIMenuItem cultguy04 = new UIMenuItem("Male Cult 4", "");
        uimenu.AddItem(cultguy04);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == cultguy04;
            if (flag)
            {
                Game.Player.ChangeModel("A_M_O_ACULT_02");
            }
        };
        UIMenuItem cultguy05 = new UIMenuItem("Male Cult 5", "");
        uimenu.AddItem(cultguy05);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == cultguy05;
            if (flag)
            {
                Game.Player.ChangeModel("A_M_Y_ACULT_02");
            }
        };
        UIMenuItem anita = new UIMenuItem("Anita", "");
        uimenu.AddItem(anita);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == anita;
            if (flag)
            {
                Game.Player.ChangeModel("CSB_ANITA");
            }
        };
        UIMenuItem barTender = new UIMenuItem("Bartender", "");
        uimenu.AddItem(barTender);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == barTender;
            if (flag)
            {
                Game.Player.ChangeModel("S_F_Y_BARTENDER_01");
            }
        };
        UIMenuItem agentSanchez = new UIMenuItem("Agent Sanchez", "");
        uimenu.AddItem(agentSanchez);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == agentSanchez;
            if (flag)
            {
                Game.Player.ChangeModel("IG_ANDREAS");
            }
        };
    }

    //Now, we will add your sub menu, which in this case, will be vehicle menu to spawn a car
    public void VehicleMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Civilian Vehicles");
        for (int i = 0; i < 1; i++)
        {
        }
        UIMenuItem tornado = new UIMenuItem("Tornado", "");
        uimenu.AddItem(tornado);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == tornado;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Tornado", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem sovereign = new UIMenuItem("Sovereign", "");
        uimenu.AddItem(sovereign);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sovereign;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Sovereign", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem hustler = new UIMenuItem("Hustler", "");
        uimenu.AddItem(hustler);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == hustler;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Hustler", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem bigRig = new UIMenuItem("Phantom", "");
        uimenu.AddItem(bigRig);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == bigRig;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Phantom", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem beachBuggy = new UIMenuItem("Bifta", "");
        uimenu.AddItem(beachBuggy);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == beachBuggy;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Bifta", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem punchBuggy = new UIMenuItem("Weevil", "");
        uimenu.AddItem(punchBuggy);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == punchBuggy;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Weevil", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem bmxBike = new UIMenuItem("BMX (Bike)", "");
        uimenu.AddItem(bmxBike);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == bmxBike;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Bmx", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem beachCruiser = new UIMenuItem("Beach Cruiser (Bike)", "");
        uimenu.AddItem(beachCruiser);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == beachCruiser;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Cruiser", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem fixter = new UIMenuItem("Fixter (Bike)", "");
        uimenu.AddItem(fixter);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == fixter;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Fixter", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem scorcherBike = new UIMenuItem("Scorcher (Bike)", "");
        uimenu.AddItem(scorcherBike);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == scorcherBike;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Scorcher", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem triBike = new UIMenuItem("Tribike", "");
        uimenu.AddItem(triBike);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == triBike;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Tribike", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem triBike2 = new UIMenuItem("Tribike 2", "");
        uimenu.AddItem(triBike2);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == triBike2;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Tribike2", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem triBike3 = new UIMenuItem("Tribike 3", "");
        uimenu.AddItem(triBike3);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == triBike3;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Tribike3", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem oppressor = new UIMenuItem("Oppressor", "");
        uimenu.AddItem(oppressor);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == oppressor;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Oppressor2", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem bati = new UIMenuItem("Bati", "");
        uimenu.AddItem(bati);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == bati;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Bati", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem faggio = new UIMenuItem("Faggio", "");
        uimenu.AddItem(faggio);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == faggio;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Faggio", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
    }

    public void WeaponMenu(UIMenu menu)
    {
        var weapons = _menuPool.AddSubMenu(menu, "Weapons");
        for (int i = 0; i < 1; i++) ;
        var newweapons = new UIMenuItem("Give Weapons", "");
        weapons.AddItem(newweapons);
        weapons.OnItemSelect += (sender, item, index) =>
        {
            if (item == newweapons)
            {
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_GOLFCLUB"), 1, true, true); //Weapon Hash, Weapon Equipped, Ammo Loaded
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
            }
        };
    }

    public void OptionsMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Options");
        for (int i = 0; i < 1; i++)
        {
        }
        UIMenuItem removeWeapons = new UIMenuItem("Remove Weapons", "");
        uimenu.AddItem(removeWeapons);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == removeWeapons)
            {
                Game.Player.Character.Weapons.RemoveAll();
            }
        };
        UIMenuItem blackOut = new UIMenuItem("Enable Black Out", "");
        uimenu.AddItem(blackOut);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == blackOut)
            {
                World.Blackout = true;
            }
        };
        UIMenuItem blackOutDisable = new UIMenuItem("Disable Black Out", "");
        uimenu.AddItem(blackOutDisable);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == blackOutDisable)
            {
                World.Blackout = false;
            }
        };
        UIMenuItem clearPeds = new UIMenuItem("Clear Area of Peds", "");
        uimenu.AddItem(clearPeds);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == clearPeds)
            {
                World.ClearAreaOfPeds(Game.Player.Character.Position, 100f);
            }
        };
        UIMenuItem clearCops = new UIMenuItem("Clear Area of Cops", "");
        uimenu.AddItem(clearCops);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == clearCops)
            {
                World.ClearAreaOfCops(Game.Player.Character.Position, 100f);
            }
        };
        UIMenuItem removeWaypoint = new UIMenuItem("Remove Waypoint", "");
        uimenu.AddItem(removeWaypoint);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == removeWaypoint)
            {
                World.RemoveWaypoint();
            }
        };
    }

    public void RadioStationMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Radio Options");
        for (int i = 0; i < 1; i++)
        {
        }
        UIMenuItem radioLosSantosRock = new UIMenuItem("Los Santos Rock", "");
        uimenu.AddItem(radioLosSantosRock);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == radioLosSantosRock)
            {
                Game.RadioStation = RadioStation.LosSantosRockRadio;
            }
        };
        UIMenuItem blaineCountyRadio = new UIMenuItem("Blaine County Radio", "");
        uimenu.AddItem(blaineCountyRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == blaineCountyRadio)
            {
                Game.RadioStation = RadioStation.BlaineCountyRadio;
            }
        };
        UIMenuItem rebelRadio = new UIMenuItem("Rebel Radio", "");
        uimenu.AddItem(rebelRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == rebelRadio)
            {
                Game.RadioStation = RadioStation.RebelRadio;
            }
        };
        UIMenuItem westCoastRadio = new UIMenuItem("West Coast Classics", "");
        uimenu.AddItem(westCoastRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == westCoastRadio)
            {
                Game.RadioStation = RadioStation.WestCoastClassics;
            }
        };
        UIMenuItem westCoastTalkRadio = new UIMenuItem("West Coast Talk Show", "");
        uimenu.AddItem(westCoastTalkRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == westCoastTalkRadio)
            {
                Game.RadioStation = RadioStation.WestCoastTalkRadio;
            }
        };
        UIMenuItem radioEastLosFM = new UIMenuItem("East Los FM", "");
        uimenu.AddItem(radioEastLosFM);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == radioEastLosFM)
            {
                Game.RadioStation = RadioStation.EastLosFM;
            }
        };
        UIMenuItem selfRadio = new UIMenuItem("Self Radio", "");
        uimenu.AddItem(selfRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == selfRadio)
            {
                Game.RadioStation = RadioStation.SelfRadio;
            }
        };
        UIMenuItem losSantosBlonded = new UIMenuItem("Blonded Los Santos", "");
        uimenu.AddItem(losSantosBlonded);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == losSantosBlonded)
            {
                Game.RadioStation = RadioStation.BlondedLosSantos;
            }
        };
        UIMenuItem xChannel = new UIMenuItem("Channel X", "");
        uimenu.AddItem(xChannel);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == xChannel)
            {
                Game.RadioStation = RadioStation.ChannelX;
            }
        };
        UIMenuItem flyloFM = new UIMenuItem("FlyloFM", "");
        uimenu.AddItem(flyloFM);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == flyloFM)
            {
                Game.RadioStation = RadioStation.FlyloFM;
            }
        };
        UIMenuItem iFruitRadio = new UIMenuItem("iFruit Radio", "");
        uimenu.AddItem(iFruitRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == iFruitRadio)
            {
                Game.RadioStation = RadioStation.iFruitRadio;
            }
        };
        UIMenuItem cultFM = new UIMenuItem("KultFM", "");
        uimenu.AddItem(cultFM);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == cultFM)
            {
                Game.RadioStation = RadioStation.KultFM;
            }
        };
        UIMenuItem infoWarsRadio = new UIMenuItem("Los Santos Underground Radio", "");
        uimenu.AddItem(infoWarsRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == infoWarsRadio)
            {
                Game.RadioStation = RadioStation.LosSantosUndergroundRadio;
            }
        };
        UIMenuItem theMediaPlayer = new UIMenuItem("Media Player", "");
        uimenu.AddItem(theMediaPlayer);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == theMediaPlayer)
            {
                Game.RadioStation = RadioStation.MediaPlayer;
            }
        };
        UIMenuItem motoMamiRadio = new UIMenuItem("Motomami Los Santos", "");
        uimenu.AddItem(motoMamiRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == motoMamiRadio)
            {
                Game.RadioStation = RadioStation.MotomamiLosSantos;
            }
        };
        UIMenuItem theMusicLocker = new UIMenuItem("Music Locker", "");
        uimenu.AddItem(theMusicLocker);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == theMusicLocker)
            {
                Game.RadioStation = RadioStation.MusicLocker;
            }
        };
        UIMenuItem nonstopRadio = new UIMenuItem("NonStop Pop FM", "");
        uimenu.AddItem(nonstopRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == nonstopRadio)
            {
                Game.RadioStation = RadioStation.NonStopPopFM;
            }
        };
        UIMenuItem lossantosRadio = new UIMenuItem("Los Santos Radio", "");
        uimenu.AddItem(lossantosRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == lossantosRadio)
            {
                Game.RadioStation = RadioStation.RadioLosSantos;
            }
        };
        UIMenuItem mirrorParkRadio = new UIMenuItem("Mirror Park Radio", "");
        uimenu.AddItem(mirrorParkRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == mirrorParkRadio)
            {
                Game.RadioStation = RadioStation.RadioMirrorPark;
            }
        };
        UIMenuItem soulwaxFM = new UIMenuItem("Soulwax FM", "");
        uimenu.AddItem(soulwaxFM);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if(item == soulwaxFM)
            {
                Game.RadioStation = RadioStation.SoulwaxFM;
            }
        };
        UIMenuItem spaceRadio = new UIMenuItem("Space Radio", "");
        uimenu.AddItem(spaceRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == spaceRadio)
            {
                Game.RadioStation = RadioStation.Space;
            }
        };
        UIMenuItem slippingLosSantos = new UIMenuItem("Still Slipping Los Santos Radio", "");
        uimenu.AddItem(slippingLosSantos);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == slippingLosSantos)
            {
                Game.RadioStation = RadioStation.StillSlippingLosSantos;
            }
        };
        UIMenuItem blueArkRadio = new UIMenuItem("The Blue Ark", "");
        uimenu.AddItem(blueArkRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == blueArkRadio)
            {
                Game.RadioStation = RadioStation.TheBlueArk;
            }
        };
        UIMenuItem theLabRadio = new UIMenuItem("The Lab", "");
        uimenu.AddItem(theLabRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == theLabRadio)
            {
                Game.RadioStation = RadioStation.TheLab;
            }
        };
        UIMenuItem lowdownRadio = new UIMenuItem("The Lowdown", "");
        uimenu.AddItem(lowdownRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == lowdownRadio)
            {
                Game.RadioStation = RadioStation.TheLowdown;
            }
        };
        UIMenuItem vinewoodRadio = new UIMenuItem("Vinewood Boulevard Radio", "");
        uimenu.AddItem(vinewoodRadio);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == vinewoodRadio)
            {
                Game.RadioStation = RadioStation.VinewoodBoulevardRadio;
            }
        };
        UIMenuItem worldWideFM = new UIMenuItem("World Wide FM", "");
        uimenu.AddItem(worldWideFM);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == worldWideFM)
            {
                Game.RadioStation = RadioStation.WorldWideFM;
            }
        };
        UIMenuItem unlockAllStations = new UIMenuItem("Unlock All Radio Stations", "");
        uimenu.AddItem(unlockAllStations);
        uimenu.OnItemSelect += (UIMenu sender, UIMenuItem item, int index) =>
        {
            if (item == unlockAllStations)
            {
                Game.UnlockAllRadioStations();
            }
        };
    }

    public void AnimalMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Animals");
        for (int i = 0; i < 1; i++)
        {
        }
        UIMenuItem pig = new UIMenuItem("Pig", "");
        uimenu.AddItem(pig);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == pig;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_PIG");
            }
        };
        UIMenuItem poodle = new UIMenuItem("Poodle", "");
        uimenu.AddItem(poodle);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == poodle;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_POODLE");
            }
        };
        UIMenuItem bugsbunny = new UIMenuItem("Rabbit", "");
        uimenu.AddItem(bugsbunny);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == bugsbunny;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_RABBIT_01");
            }
        };
        UIMenuItem wildHog = new UIMenuItem("Boar", "");
        uimenu.AddItem(wildHog);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == wildHog;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_BOAR");
            }
        };
        UIMenuItem pussyCat = new UIMenuItem("Pussy Cat", "");
        uimenu.AddItem(pussyCat);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == pussyCat;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_CAT_01");
            }
        };
        UIMenuItem chickenHawk = new UIMenuItem("Chicken Hawk", "");
        uimenu.AddItem(chickenHawk);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == chickenHawk;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_CHICKENHAWK");
            }
        };
        UIMenuItem monkey = new UIMenuItem("Monkey", "");
        uimenu.AddItem(monkey);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == monkey;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_CHIMP");
            }
        };
        UIMenuItem seagull = new UIMenuItem("Seagull", "");
        uimenu.AddItem(seagull);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == seagull;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_CORMORANT");
            }
        };
        UIMenuItem cow = new UIMenuItem("Cow", "");
        uimenu.AddItem(cow);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == cow;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_COW");
            }
        };
        UIMenuItem coyote = new UIMenuItem("Coyote", "");
        uimenu.AddItem(coyote);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == coyote;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_COYOTE");
            }
        };
    }

    

    //Now we will add all of our sub menus into our main menu, and set the general information of the entire menu
    public SimplePedMenu()
    {
        this._menuPool = new MenuPool();
        UIMenu mainMenu = new UIMenu("~o~Simple Ped Menu", "~b~Mod by~w~ JonJonGames ~y~v1.0");
        this._menuPool.Add(mainMenu);
        this.PlayerModelMenu(mainMenu);
        this.VehicleMenu(mainMenu);
        WeaponMenu(mainMenu);
        this.AnimalMenu(mainMenu);
        this.RadioStationMenu(mainMenu);
        this.OptionsMenu(mainMenu);
        this._menuPool.RefreshIndex();
        this.config = ScriptSettings.Load("scripts\\SimplePedMenu.ini");
        this.OpenMenu = this.config.GetValue<Keys>("Options", "OpenMenu", Keys.F9);
        base.Tick += delegate (object o, EventArgs e)
        {
            this._menuPool.ProcessMenus();
        };
        base.KeyDown += delegate (object o, KeyEventArgs e)
        {
            bool flag = e.KeyCode == this.OpenMenu && !this._menuPool.IsAnyMenuOpen();
            if (flag)
            {
                Cursor.Hide();
                mainMenu.Visible = !mainMenu.Visible;
            }
        };
    }
}
//Useful Links
//All Vehicles - https://pastebin.com/uTxZnhaN
//All Player Models - https://pastebin.com/i5c1zA0W
//All Weapons - https://pastebin.com/M3kD9pnJ
//Native UI - https://gtaforums.com/topic/809284-net-nativeui/
//GTA V ScriptHook V Dot Net - https://www.gta5-mods.com/tools/scripthookv-net