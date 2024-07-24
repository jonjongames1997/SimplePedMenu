// Native UI Menu Template 3.0 - Abel Software
// You must download and use Scripthook V Dot Net Reference and NativeUI Reference (LINKS AT BOTTOM OF THE TEMPLATE)
using GTA;
using GTA.Native;
using NativeUI;
using System.Windows.Forms;

public class NativeUITemplate : Script
{
    private Ped playerPed = Game.Player.Character;
    private Player player = Game.Player;
    private MenuPool _menuPool;

    //Here we will add the code to use a .INI file for your menu open key
    ScriptSettings config;
    Keys OpenMenu;

    //Now, we will add your sub menu, which in this case, will be player menu to change your player model.
    public void PlayerModelMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Simple Ped Menu");
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
        UIMenuItem wadeCrackhead = new UIMenuItem("Wade", "");
        uimenu.AddItem(wadeCrackhead);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == wadeCrackhead;
            if (flag)
            {
                Game.Player.ChangeModel("IG_WADE");
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
        UIMenuItem sexyMolly = new UIMenuItem("Molly", "");
        uimenu.AddItem(sexyMolly);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sexyMolly;
            if (flag)
            {
                Game.Player.ChangeModel("IG_MOLLY");
            }
        };
        UIMenuItem karenDaniels = new UIMenuItem("Karen Daniels", "");
        uimenu.AddItem(karenDaniels);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == karenDaniels;
            if (flag)
            {
                Game.Player.ChangeModel("IG_KAREN_DANIELS");
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
    }

    //Now, we will add your sub menu, which in this case, will be weapon menu to equip a weapon
    public void WeaponMenu(UIMenu menu)
    {
        var weapons = _menuPool.AddSubMenu(menu, "Weapon Menu");
        for (int i = 0; i < 1; i++) ;

        //For this example, we will equipping a flashlight, combat pistol, and pump shotgun
        var newweapons = new UIMenuItem("Give Weapons", "");
        weapons.AddItem(newweapons);
        weapons.OnItemSelect += (sender, item, index) =>
        {
            if (item == newweapons)
            {
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_GOLFCLUB"), 1, true, true); //Weapon Hash, Weapon Equipped, Ammo Loaded
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_COMBATPISTOL"), 9999, false, true);
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_TACTICALRIFLE"), 9999, false, true);
                UI.Notify("~g~You have been issued weapons!"); //This notification will appear with green text above the radar
                UI.ShowSubtitle("~g~You have been issued weapons!"); //This notification will appear at the bottom of the screen with green text
            }
        };
    }

    //Now we will add all of our sub menus into our main menu, and set the general information of the entire menu
    public NativeUITemplate()
    {
        _menuPool = new MenuPool();
        var mainMenu = new UIMenu("~o~Simple Ped Menu~w~", "~b~by Jon Jon Games Official. ~y~v0.1~w~.");
        _menuPool.Add(mainMenu);
        PlayerModelMenu(mainMenu); //Here we add the Player Model Sub Menu
        VehicleMenu(mainMenu); //Here we add the Vehicle Spawning Sub Menu
        WeaponMenu(mainMenu); //Here we add the Weapon Sub Menu
        _menuPool.RefreshIndex();
        config = ScriptSettings.Load("scripts\\SimplePedMenu.ini");
        OpenMenu = config.GetValue<Keys>("Options", "OpenMenu", Keys.F9);
        Tick += (o, e) => _menuPool.ProcessMenus();
        KeyDown += (o, e) =>
        {
            if (e.KeyCode == OpenMenu && !_menuPool.IsAnyMenuOpen()) // Our menu on/off switch
                mainMenu.Visible = !mainMenu.Visible;
        };
    }
}
//Useful Links
//All Vehicles - https://pastebin.com/uTxZnhaN
//All Player Models - https://pastebin.com/i5c1zA0W
//All Weapons - https://pastebin.com/M3kD9pnJ
//Native UI - https://gtaforums.com/topic/809284-net-nativeui/
//GTA V ScriptHook V Dot Net - https://www.gta5-mods.com/tools/scripthookv-net