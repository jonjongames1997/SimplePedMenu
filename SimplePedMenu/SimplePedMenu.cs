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
    private int amount;

    //Now, we will add your sub menu, which in this case, will be player menu to change your player model.
    public void PlayerModelMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Ped Menu");
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
        var wadeCrackhead = new UIMenuItem("Wade", "");
        uimenu.AddItem(wadeCrackhead);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == wadeCrackhead)
            {
                Game.Player.ChangeModel("CS_WADE");
                Game.Player.Character.IsVisible = true;
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
        var sexyMolly = new UIMenuItem("Molly Shultz", "");
        uimenu.AddItem(sexyMolly);
        uimenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == sexyMolly)
            {
                Game.Player.ChangeModel("IG_MOLLY");
                Game.Player.Character.IsVisible = true;
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
        var traceyDeSanta = new UIMenuItem("Tracey DeSanta", "");
        uimenu.AddItem(traceyDeSanta);
        uimenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == traceyDeSanta)
            {
                Game.Player.ChangeModel("CS_TRACYDISANTO");
                Game.Player.Character.IsVisible = true;
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
        UIMenuItem nervousRon = new UIMenuItem("Nervous Ron", "");
        uimenu.AddItem(nervousRon);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == nervousRon;
            if (flag)
            {
                Game.Player.ChangeModel("IG_NERVOUSRON");
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
    }

    public void WeaponeMenu(UIMenu menu)
    {
        var weapons = _menuPool.AddSubMenu(menu, "Weapon Menu");
        for (int i = 0; i < 1; i++) ;

        var shotgun = new UIMenuItem("Pump ShotGun", "");
        weapons.AddItem(shotgun);
        weapons.OnItemSelect += (sender, item, index) =>
        {
            if (item == shotgun)
            {
                Game.Player.Character.Weapons.Give("WEAPON_PUMPSHOTGUN", 9999, false, true);
            }
        };

        var pistol = new UIMenuItem("Pistol", "");
        weapons.AddItem(pistol);
        weapons.OnItemSelect += (sender, item, index) =>
        {
            if (item == pistol)
            {
                Game.Player.Character.Weapons.Give( "WEAPON_PISTOL", 9999, false, true);
            }
        };

        var carbinerifle = new UIMenuItem("Carbine Rifle", "");
        weapons.AddItem(carbinerifle);
        weapons.OnItemSelect += (sender, item, index) =>
        {
            if (item == carbinerifle)
            {
                Game.Player.Character.Weapons.Give("WEAPON_CARBINERIFLE", 9999, false, true);
            }
        };

        var tacticalrifle = new UIMenuItem("Tactical Rifle", "");
        weapons.AddItem(tacticalrifle);
        weapons.OnItemSelect += (sender, item, index) =>
        {
            if (item == carbinerifle)
            {
                Game.Player.Character.Weapons.Give("WEAPON_TACTICALRIFLE", 9999, false, true);
            }
        };
    }

    public void MoneyMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Money Menu");
        for (int i = 0; i < 1; i++)
        {
        }
        UIMenuItem oneThousandDollars = new UIMenuItem("$1,000", "");
        uimenu.AddItem(oneThousandDollars);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == oneThousandDollars;
            if (flag)
            {
                Game.Player.Money += this.amount;
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
        this.WeaponeMenu(mainMenu);
        this.MoneyMenu(mainMenu);
        this._menuPool.RefreshIndex();
        this.config = ScriptSettings.Load("scripts\\SimplePedMenu.ini");
        this.OpenMenu = this.config.GetValue<Keys>("Options", "OpenMenu", Keys.F9);
        base.Tick += delegate (object o, EventArgs e)
        {
            this._menuPool.ProcessMenus();
        };
        base.Tick += delegate (object o, EventArgs e)
        {
            Game.Player.WantedLevel = 0;
        };
        base.KeyDown += delegate (object o, KeyEventArgs e)
        {
            bool flag = e.KeyCode == this.OpenMenu && !this._menuPool.IsAnyMenuOpen();
            if (flag)
            {
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