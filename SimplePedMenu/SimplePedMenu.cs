// Native UI Menu Template 3.0 - Abel Software
// You must download and use Scripthook V Dot Net Reference and NativeUI Reference (LINKS AT BOTTOM OF THE TEMPLATE)
using GTA;
using NativeUI;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }

    //Now we will add all of our sub menus into our main menu, and set the general information of the entire menu
    public SimplePedMenu()
    {
        this._menuPool = new MenuPool();
        UIMenu mainMenu = new UIMenu("~o~Simple Ped Menu", "~b~by JonJonGames ~y~V 1.0");
        this._menuPool.Add(mainMenu);
        this.PlayerModelMenu(mainMenu);
        this.VehicleMenu(mainMenu);
        WeaponMenu(mainMenu);
        this.AnimalMenu(mainMenu);
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
                mainMenu.Visible = !mainMenu.Visible;
                Cursor.Hide();
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