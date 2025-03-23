using GTA;
using NativeUI;
using System.Windows.Forms;
using System;
using GTA.Native;
using static GTA.ScriptSettings;
using Newtonsoft.Json.Serialization;

public class SimplePedMenu : Script
{
    #region // General Variables //
    private Ped playerPed = Game.Player.Character;
    private Player player = Game.Player;
    private readonly MenuPool _menuPool;
    private readonly ScriptSettings config;
    private readonly Keys OpenMenu;
    #endregion

    #region // Ped Model Menu //
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
        UIMenuItem impotentRage = new UIMenuItem("Impotent Rage", "");
        uimenu.AddItem(impotentRage);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == impotentRage;
            if (flag)
            {
                Game.Player.ChangeModel("U_M_Y_IMPORAGE");
            }
        };
        UIMenuItem airhostess = new UIMenuItem("Air Hostess", "");
        uimenu.AddItem(airhostess);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == airhostess;
            if (flag)
            {
                Game.Player.ChangeModel("S_F_Y_AIRHOSTESS_01");
            }
        };
        UIMenuItem aldiNapoli = new UIMenuItem("Aldinapoli", "");
        uimenu.AddItem(aldiNapoli);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == aldiNapoli;
            if (flag)
            {
                Game.Player.ChangeModel("U_M_M_ALDINAPOLI");
            }
        };
        UIMenuItem gunshopOwner = new UIMenuItem("Gun Shop Owner", "");
        uimenu.AddItem(gunshopOwner);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == gunshopOwner;
            if (flag)
            {
                Game.Player.ChangeModel("S_M_Y_AMMUCITY_01");
            }
        };
        UIMenuItem femaleBallas = new UIMenuItem("Female Ballas", "");
        uimenu.AddItem(femaleBallas);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == femaleBallas;
            if (flag)
            {
                Game.Player.ChangeModel("G_F_Y_BALLAS_01");
            }
        };
        UIMenuItem theBankManager = new UIMenuItem("Bank Manager", "");
        uimenu.AddItem(theBankManager);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == theBankManager;
            if (flag)
            {
                Game.Player.ChangeModel("IG_BANKMAN");
            }
        };
        UIMenuItem bikerChick = new UIMenuItem("Female Biker Chick", "");
        uimenu.AddItem(bikerChick);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == bikerChick;
            if (flag)
            {
                Game.Player.ChangeModel("U_F_Y_BIKERCHIC");
            }
        };
        UIMenuItem Coroner = new UIMenuItem("Coroner", "");
        uimenu.AddItem(Coroner);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == Coroner;
            if (flag)
            {
                Game.Player.ChangeModel("S_M_Y_AUTOPSY_01");
            }
        };
        UIMenuItem femaleLifeguard = new UIMenuItem("Lifeguard (Female)", "");
        uimenu.AddItem(femaleLifeguard);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == femaleLifeguard;
            if (flag)
            {
                Game.Player.ChangeModel("S_F_Y_BAYWATCH_01");
            }
        };
        UIMenuItem FemaleBeachgoer = new UIMenuItem("Female Beachgoer", "");
        uimenu.AddItem(FemaleBeachgoer);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == FemaleBeachgoer;
            if (flag)
            {
                Game.Player.ChangeModel("A_F_M_BEACH_01");
            }
        };
        UIMenuItem InfernusStripper = new UIMenuItem("Stripper - Infernus", "");
        uimenu.AddItem(InfernusStripper);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == InfernusStripper;
            if (flag)
            {
                Game.Player.ChangeModel("S_F_Y_STRIPPER_02");
            }
        };
        UIMenuItem BusinessWoman = new UIMenuItem("Business Woman 1", "");
        uimenu.AddItem(BusinessWoman);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == BusinessWoman;
            if (flag)
            {
                Game.Player.ChangeModel("A_F_Y_BUSINESS_01");
            }
        };
        UIMenuItem ConstructionWorker = new UIMenuItem("Construction Worker 1", "");
        uimenu.AddItem(ConstructionWorker);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == ConstructionWorker;
            if (flag)
            {
                Game.Player.ChangeModel("S_M_Y_CONSTRUCT_02");
            }
        };
        UIMenuItem DrugDealer = new UIMenuItem("Drug Dealer", "");
        uimenu.AddItem(DrugDealer);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == DrugDealer;
            if (flag)
            {
                Game.Player.ChangeModel("S_M_Y_DEALER_01");
            }
        };
        UIMenuItem AirportWorker = new UIMenuItem("Airport Worker", "");
        uimenu.AddItem(AirportWorker);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == AirportWorker;
            if (flag)
            {
                Game.Player.ChangeModel("S_M_Y_AIRWORKER");
            }
        };
        UIMenuItem JanetBartender = new UIMenuItem("Janet", "");
        uimenu.AddItem(JanetBartender);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == JanetBartender;
            if (flag)
            {
                Game.Player.ChangeModel("IG_JANET");
            }
        };
        UIMenuItem KerryMcIntosh = new UIMenuItem("Kerry McIntosh", "");
        uimenu.AddItem(KerryMcIntosh);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == KerryMcIntosh;
            if (flag)
            {
                Game.Player.ChangeModel("IG_KERRYMCINTOSH");
            }
        };
        UIMenuItem businessWoman = new UIMenuItem("Business Woman 1", "");
        uimenu.AddItem(businessWoman);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == businessWoman;
            if (flag)
            {
                Game.Player.ChangeModel("A_F_Y_BUSINESS_01");
            }
        };
        UIMenuItem businessWoman2 = new UIMenuItem("Business Woman 2", "");
        uimenu.AddItem(businessWoman2);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == businessWoman2;
            if (flag)
            {
                Game.Player.ChangeModel("A_F_Y_BUSINESS_02");
            }
        };
        UIMenuItem businessWoman3 = new UIMenuItem("Business Woman 3", "");
        uimenu.AddItem(businessWoman3);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == businessWoman3;
            if (flag)
            {
                Game.Player.ChangeModel("A_F_Y_BUSINESS_03");
            }
        };
        UIMenuItem shirtlessDude = new UIMenuItem("Shirtless Dude", "");
        uimenu.AddItem(shirtlessDude);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == shirtlessDude;
            if(flag)
            {
                Game.Player.ChangeModel("U_M_Y_ABNER");
            }
        };
        UIMenuItem footballFan = new UIMenuItem("Football Fan", "");
        uimenu.AddItem(footballFan);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == footballFan;
            if (flag)
            {
                Game.Player.ChangeModel("a_m_m_afriamer_01");
            }
        };
        UIMenuItem carMechanic = new UIMenuItem("Car Mechanic", "");
        uimenu.AddItem(carMechanic);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == carMechanic;
            if (flag)
            {
                Game.Player.ChangeModel("s_m_m_autoshop_01");
            }
        };
        UIMenuItem ClassyWoman = new UIMenuItem("Classy Woman", "");
        uimenu.AddItem(ClassyWoman);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == ClassyWoman;
            if (flag)
            {
                Game.Player.ChangeModel("a_f_y_bevhills_01");
            }
        };
        UIMenuItem FemaleLSPDWhiteCop = new UIMenuItem("LSPD Female Cop", "");
        uimenu.AddItem(FemaleLSPDWhiteCop);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == FemaleLSPDWhiteCop;
            if (flag)
            {
                Game.Player.ChangeModel("s_f_y_cop_01");
            }
        };
        UIMenuItem LSPDCop = new UIMenuItem("LSPD Male Cop", "");
        uimenu.AddItem(LSPDCop);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == LSPDCop;
            if (flag)
            {
                Game.Player.ChangeModel("s_m_y_cop_01");
            }
        };
        UIMenuItem deadCorpse = new UIMenuItem("Dead Corpse 1", "");
        uimenu.AddItem(deadCorpse);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == deadCorpse;
            if (flag)
            {
                Game.Player.ChangeModel("u_f_m_corpse_01");
            }
        };
        UIMenuItem militaryPed1 = new UIMenuItem("Military Guy 1", "");
        uimenu.AddItem(militaryPed1);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == militaryPed1;
            if (flag)
            {
                Game.Player.ChangeModel("s_m_y_blackops_01");
            }
        };
        UIMenuItem militaryPed2 = new UIMenuItem("Military Guy 2", "");
        uimenu.AddItem(militaryPed2);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == militaryPed2;
            if (flag)
            {
                Game.Player.ChangeModel("s_m_y_blackops_02");
            }
        };
        UIMenuItem militaryPed3 = new UIMenuItem("Military Guy 3", "");
        uimenu.AddItem(militaryPed3);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == militaryPed3;
            if (flag)
            {
                Game.Player.ChangeModel("s_m_y_blackops_03");
            }
        };
        UIMenuItem theBride = new UIMenuItem("Bride", "");
        uimenu.AddItem(theBride);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == theBride;
            if (flag)
            {
                Game.Player.ChangeModel("ig_bride");
            }
        };
        UIMenuItem caseyGruppe = new UIMenuItem("Casey", "");
        uimenu.AddItem(caseyGruppe);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == caseyGruppe;
            if (flag)
            {
                Game.Player.ChangeModel("ig_casey");
            }
        };
        UIMenuItem breakdancer = new UIMenuItem("Break Dancer", "");
        uimenu.AddItem(breakdancer);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == breakdancer;
            if (flag)
            {
                Game.Player.ChangeModel("a_m_y_breakdance_01");
            }
        };
        UIMenuItem burgershotDrugDealer = new UIMenuItem("Burger Shot Drug Dealer", "");
        uimenu.AddItem(burgershotDrugDealer);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == burgershotDrugDealer;
            if (flag)
            {
                Game.Player.ChangeModel("u_m_y_burgerdrug_01");
            }
        };
        UIMenuItem imaniDLC = new UIMenuItem("Imani [The Contract DLC]", "");
        uimenu.AddItem(imaniDLC);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == imaniDLC;
            if (flag)
            {
                Game.Player.ChangeModel("IG_IMANI");
            }
        };
        UIMenuItem luchadora = new UIMenuItem("Luchadora [Los Santos Drug Wars DLC]", "");
        uimenu.AddItem(luchadora);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == luchadora;
            if (flag)
            {
                Game.Player.ChangeModel("IG_LUCHADORA");
            }
        };
        UIMenuItem masonDugganDLC = new UIMenuItem("Mason Duggan [The Criminal Enterprises DLC]", "");
        uimenu.AddItem(masonDugganDLC);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == masonDugganDLC;
            if (flag)
            {
                Game.Player.ChangeModel("IG_MASON_DUGGAN");
            }
        };
        UIMenuItem carBuyer = new UIMenuItem("Car Buyer", "");
        uimenu.AddItem(carBuyer);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == carBuyer;
            if (flag)
            {
                Game.Player.ChangeModel("cs_carbuyer");
            }
        };
        UIMenuItem chemicalWorker = new UIMenuItem("Chemical Worker", "");
        uimenu.AddItem(chemicalWorker);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == chemicalWorker;
            if (flag)
            {
                Game.Player.ChangeModel("g_m_m_chemwork_01");
            }
        };
        UIMenuItem clayPain = new UIMenuItem("Claypain", "");
        uimenu.AddItem(clayPain);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == clayPain;
            if (flag)
            {
                Game.Player.ChangeModel("ig_claypain");
            }
        };
    }
    #endregion

    #region // Vehicle Menu //
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
        UIMenuItem hermes = new UIMenuItem("Hermes", "");
        uimenu.AddItem(hermes);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == hermes;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Hermes", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem duneBuggy = new UIMenuItem("Dune", "");
        uimenu.AddItem(duneBuggy);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == duneBuggy;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Dune", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem outlaw = new UIMenuItem("Outlaw", "");
        uimenu.AddItem(outlaw);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == outlaw;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Outlaw", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem benson = new UIMenuItem("Benson", "");
        uimenu.AddItem(benson);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == benson;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Benson", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem mule1 = new UIMenuItem("Mule 1", "");
        uimenu.AddItem(mule1);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == mule1;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Mule", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem dinghy5 = new UIMenuItem("Dinghy 5", "");
        uimenu.AddItem(dinghy5);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == dinghy5;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Dinghy5", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem jetMax = new UIMenuItem("Jetmax", "");
        uimenu.AddItem(jetMax);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == jetMax;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Jetmax", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem gunTruck = new UIMenuItem("Technical", "");
        uimenu.AddItem(gunTruck);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == gunTruck;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Technical", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem gunTruck2 = new UIMenuItem("Technical 2", "");
        uimenu.AddItem(gunTruck2);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == gunTruck2;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Technical2", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem dumpTruck = new UIMenuItem("Dump Truck", "");
        uimenu.AddItem(dumpTruck);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == dumpTruck;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Dump", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem flatbedTow = new UIMenuItem("Flatbed", "");
        uimenu.AddItem(flatbedTow);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == flatbedTow;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Flatbed", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem faggio3 = new UIMenuItem("Faggio 3", "");
        uimenu.AddItem(faggio3);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == faggio3;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Faggio3", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem stryderBike = new UIMenuItem("Stryder", "");
        uimenu.AddItem(stryderBike);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == stryderBike;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("Stryder", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem terrorbyte = new UIMenuItem("Terrorbyte", "");
        uimenu.AddItem(terrorbyte);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == terrorbyte;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("terbyte", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem moneyTruck = new UIMenuItem("Stockade", "");
        uimenu.AddItem(moneyTruck);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == moneyTruck;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("stockade", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem asbo = new UIMenuItem("Asbo", "");
        uimenu.AddItem(asbo);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == asbo;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("asbo", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem blista = new UIMenuItem("Blista", "");
        uimenu.AddItem(blista);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == blista;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("blista", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem barrage = new UIMenuItem("Barrage", "");
        uimenu.AddItem(barrage);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == barrage;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("barrage", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem cargoBob = new UIMenuItem("Cargobob", "");
        uimenu.AddItem(cargoBob);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == cargoBob;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("cargobob", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem buzzard = new UIMenuItem("Buzzard", "");
        uimenu.AddItem(buzzard);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == buzzard;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("buzzard", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
        UIMenuItem minitank = new UIMenuItem("Minitank", "");
        uimenu.AddItem(minitank);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == minitank;
            if (flag)
            {
                Vehicle vehicle = World.CreateVehicle("minitank", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
        };
    }
    #endregion

    #region // Animations Menu //
    public void MPAnimationsMenu(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Animations");
        for (int i = 0; i < 1; i++)
        {
        }
        UIMenuItem StopAnimation = new UIMenuItem("Josh Chilling", "");
        uimenu.AddItem(StopAnimation);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == StopAnimation;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("rcmjosh1", "idle");
            }
        };
        UIMenuItem dance1 = new UIMenuItem("Peace Sign", "");
        uimenu.AddItem(dance1);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == dance1;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_upperpeace_sign", "mp_player_int_peace_sign");
            }
        };
        UIMenuItem GangSign1 = new UIMenuItem("Gang Sign 1", "");
        uimenu.AddItem(GangSign1);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == GangSign1;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_uppergang_sign_a", "mp_player_int_gang_sign_a");
            }
        };
        UIMenuItem GangSign2 = new UIMenuItem("Gang Sign 2", "");
        uimenu.AddItem(GangSign2);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == GangSign2;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_uppergang_sign_b", "mp_player_int_gang_sign_b");
            }
        };
        UIMenuItem RockSign = new UIMenuItem("Rock", "");
        uimenu.AddItem(RockSign);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == RockSign;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_upperrock", "mp_player_int_rock");
            }
        };
        UIMenuItem HandSalute = new UIMenuItem("Hand Salute", "");
        uimenu.AddItem(HandSalute);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == HandSalute;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_uppersalute", "mp_player_int_salute");
            }
        };
        UIMenuItem ChinBrush = new UIMenuItem("Chin Brush", "");
        uimenu.AddItem(ChinBrush);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == ChinBrush;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperchin_brush", "exit");
            }
        };
        UIMenuItem TakePill = new UIMenuItem("Take Pill", "");
        uimenu.AddItem(TakePill);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == TakePill;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_suicide", "pill");
            }
        };
        UIMenuItem upYours = new UIMenuItem("Up Yours", "");
        uimenu.AddItem(upYours);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == upYours;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_upperup_yours", "mp_player_int_up_yours_exit");
            }
        };
        UIMenuItem wanking = new UIMenuItem("Wank", "");
        uimenu.AddItem(wanking);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == wanking;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_upperwank", "mp_player_int_wank_01");
            }
        };
        UIMenuItem hostage = new UIMenuItem("Pistol to the Head", "");
        uimenu.AddItem(hostage);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == hostage;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_suicide", "pistol");
            }
        };
        UIMenuItem flippingOff = new UIMenuItem("Flipping the Bird", "");
        uimenu.AddItem(flippingOff);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
           bool flag = item == flippingOff;
           if (flag)
           {
                Game.Player.Character.Task.PlayAnimation("mp_player_intfinger", "mp_player_int_finger");
           }
        };
        UIMenuItem loveBro = new UIMenuItem("Bro Love", "");
        uimenu.AddItem(loveBro);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == loveBro;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_upperbro_love", "mp_player_int_bro_love");
            }
        };
        UIMenuItem headNod = new UIMenuItem("Head Nod", "");
        uimenu.AddItem(headNod);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == headNod;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_upper_nod", "mp_player_int_nod_no");
            }
        };
        UIMenuItem docking = new UIMenuItem("Docking", "");
        uimenu.AddItem(docking);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == docking;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperdock", "exit_fp");
            }
        };
        UIMenuItem grabbingtheDick = new UIMenuItem("Grab Deez Nuts", "");
        uimenu.AddItem(grabbingtheDick);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == grabbingtheDick;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_uppergrab_crotch", "mp_player_int_grab_crotch");
            }
        };
        UIMenuItem facepalm = new UIMenuItem("Face Palm", "");
        uimenu.AddItem(facepalm);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == facepalm;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperface_palm", "enter_fp");
            }
        };
        UIMenuItem diggingForCheese = new UIMenuItem("Digging for Cheese", "");
        uimenu.AddItem(diggingForCheese);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == diggingForCheese;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_player_int_upperarse_pick", "mp_player_int_arse_pick");
            }
        };
        UIMenuItem mouthYapping = new UIMenuItem("Mouth Yapping", "");
        uimenu.AddItem(mouthYapping);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == mouthYapping;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_facial", "mic_chatter");
            }
        };
        UIMenuItem leaning = new UIMenuItem("Leaning", "");
        uimenu.AddItem(leaning);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == leaning;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_cp_welcome_tutleaning", "idle_a");
            }
        };
        UIMenuItem airGuitar = new UIMenuItem("Air Guitar", "");
        uimenu.AddItem(airGuitar);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == airGuitar;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperair_guitar", "idle_a_fp");
            }
        };
        UIMenuItem crunchingKnuckles = new UIMenuItem("Crunching Knuckles", "");
        uimenu.AddItem(crunchingKnuckles);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == crunchingKnuckles;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperknuckle_crunch", "idle_a");
            }
        };
        UIMenuItem nosePicking = new UIMenuItem("Nose Picking", "");
        uimenu.AddItem(nosePicking);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == nosePicking;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intuppernose_pick", "enter");
            }
        };
        UIMenuItem djing = new UIMenuItem("DJ", "");
        uimenu.AddItem(djing);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == djing;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperdj", "idle_a");
            }
        };
        UIMenuItem BeQuiet = new UIMenuItem("Be Quiet", "");
        uimenu.AddItem(BeQuiet);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == BeQuiet;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intuppershush", "enter");
            }
        };
        UIMenuItem thumbsUp = new UIMenuItem("Thumbs Up", "");
        uimenu.AddItem(thumbsUp);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == thumbsUp;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperthumbs_up", "enter");
            }
        };
        UIMenuItem slowclapping = new UIMenuItem("Slow Clapping", "");
        uimenu.AddItem(slowclapping);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == slowclapping;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperslow_clap", "idle_a");
            }
        };
        UIMenuItem ISurrender = new UIMenuItem("Surrendering", "");
        uimenu.AddItem(ISurrender);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == ISurrender;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intuppersurrender", "enter");
            }
        };
        UIMenuItem MakeItRain = new UIMenuItem("Make It Rain", "");
        uimenu.AddItem(MakeItRain);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == MakeItRain;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperraining_cash", "idle_a");
            }
        };
        UIMenuItem yourLoco = new UIMenuItem("Your Loco", "");
        uimenu.AddItem(yourLoco);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == yourLoco;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperyou_loco", "idle_a");
            }
        };
        UIMenuItem Waving = new UIMenuItem("Waving", "");
        uimenu.AddItem(Waving);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == Waving;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperwave", "idle_a");
            }
        };
        UIMenuItem Disco = new UIMenuItem("70s Disco", "");
        uimenu.AddItem(Disco);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == Disco;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperuncle_disco", "idle_a");
            }
        };
        UIMenuItem pluggingEars = new UIMenuItem("Plugging Ears", "");
        uimenu.AddItem(pluggingEars);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == pluggingEars;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intupperthumb_on_ears", "idle_a");
            }
        };
        UIMenuItem amandaIdle = new UIMenuItem("Amanda Sitting Idle", "");
        uimenu.AddItem(amandaIdle);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == amandaIdle;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("timetable@reunited@ig_10", "base_amanda");
            }
        };
        UIMenuItem meditateIdle = new UIMenuItem("Meditate", "");
        uimenu.AddItem(meditateIdle);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == meditateIdle;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("rcmcollect_paperleadinout@", "meditiate_idle");
            }
        };
        UIMenuItem twerking = new UIMenuItem("Twerk", "");
        uimenu.AddItem(twerking);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == twerking;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("switch@trevor@mocks_lapdance", "001443_01_trvs_28_idle_stripper");
            }
        };
        UIMenuItem PrivatedanceIdle = new UIMenuItem("Private Dance Idle", "");
        uimenu.AddItem(PrivatedanceIdle);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == PrivatedanceIdle;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mini@strip_club@private_dance@idle", "priv_dance_idle");
            }
        };
        UIMenuItem lapdance2 = new UIMenuItem("Lap Dance 2", "");
        uimenu.AddItem(lapdance2);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == lapdance2;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mini@strip_club@lap_dance_2g@ld_2g_p1", "ld_2g_p1_s2");
            }
        };
        UIMenuItem BBQanim = new UIMenuItem("BBQ", "");
        uimenu.AddItem(BBQanim);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == BBQanim;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("amb@prop_human_bbq@male@idle_a", "idle_b");
            }
        };
        UIMenuItem trevorPuking = new UIMenuItem("Trevor Puking", "");
        uimenu.AddItem(trevorPuking);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == trevorPuking;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("missheistpaletoscore1leadinout", "trv_puking_leadout");
            }
        };
        UIMenuItem callChop = new UIMenuItem("Call Chop", "");
        uimenu.AddItem(callChop);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == callChop;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("missfra0_chop_find", "call_chop_l");
            }
        };
        UIMenuItem carmeetCheckoutCar = new UIMenuItem("Checking Out Car Carmeet", "");
        uimenu.AddItem(carmeetCheckoutCar);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == carmeetCheckoutCar;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@amb@carmeet@checkout_car@", "female_c_idle_d");
            }
        };
        UIMenuItem lapDanceStripper = new UIMenuItem("Lap Dance 3", "");
        uimenu.AddItem(lapDanceStripper);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == lapDanceStripper;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mp_am_stripper", "lap_dance_girl");
            }
        };
        UIMenuItem lapDanceStripper2 = new UIMenuItem("Lap Dance 4", "");
        uimenu.AddItem(lapDanceStripper2);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == lapDanceStripper2;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("mini@strip_club@private_dance@part1", "priv_dance_p1");
            }
        };
        UIMenuItem yachtLapDance = new UIMenuItem("Yacht Lap Dance", "");
        uimenu.AddItem(yachtLapDance);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == yachtLapDance;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("oddjobs@assassinate@multi@yachttarget@lapdance", "yacht_ld_f");
            }
        };
        UIMenuItem bitchSlap = new UIMenuItem("Bitch Slap", "");
        uimenu.AddItem(bitchSlap);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == bitchSlap;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("melee@unarmed@streamed_variations", "plyr_takedown_front_slap");
            }
        };
        UIMenuItem headButt = new UIMenuItem("Head Butt", "");
        uimenu.AddItem(headButt);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == headButt;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("melee@unarmed@streamed_variations", "plyr_takedown_front_headbutt");
            }
        };
        UIMenuItem sassyMiddleFinger = new UIMenuItem("Sassy Middle Finger", "");
        uimenu.AddItem(sassyMiddleFinger);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sassyMiddleFinger;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@mp_player_intcelebrationfemale@finger", "finger");
            }
        };
        UIMenuItem gettingDicked = new UIMenuItem("Getting Dicked (NSFW)", "");
        uimenu.AddItem(gettingDicked);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == gettingDicked;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("rcmpaparazzo_2", "shag_action_poppy");
            }
        };
        UIMenuItem Buttwag = new UIMenuItem("Buttwag", "");
        uimenu.AddItem(Buttwag);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == Buttwag;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("special_ped@mountain_dancer@monologue_3@monologue_3a", "mnt_dnc_buttwag");
            }
        };
        UIMenuItem smokingFemale = new UIMenuItem("Smoking (Female)", "");
        uimenu.AddItem(smokingFemale);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == smokingFemale;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("amb@world_human_smoking@female@idle_a", "idle_b");
            }
        };
        UIMenuItem sillyDance1 = new UIMenuItem("Silly Dance 1", "");
        uimenu.AddItem(sillyDance1);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == sillyDance1;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("anim@amb@nightclub@lazlow@hi_dancefloor@", "crowddance_hi_11_handup_laz");
            }
        };
        UIMenuItem situps = new UIMenuItem("Situps", "");
        uimenu.AddItem(situps);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == situps;
            if (flag)
            {
                Game.Player.Character.Task.PlayAnimation("amb@world_human_sit_ups@male@idle_a", "idle_a");
            }
        };
    }
    #endregion

    #region // Weapon Menu //
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
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_PISTOL"), 9999, false, true);
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_STUNGUN"), 9999, false, true);
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SNSPISTOL"), 9999, false, true);
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_RAYPISTOL"), 9999, false, true);
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SWITCHBLADE"), 9999, true, true);
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_SMG"), 9999, false, true);
            }
        };
        var dropWeapon = new UIMenuItem("Drop Weapon", "");
        weapons.AddItem(dropWeapon);
        weapons.OnItemSelect += (sender, item, index) =>
        {
            if (item == dropWeapon)
            {
                Game.Player.Character.Weapons.Drop();
            }
        };
    }
    #endregion

    #region // Options Menu //
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
                BigMessageThread.MessageInstance.ShowSimpleShard("SUCCESS", "Weapons Removed successfully! :-)");
            }
        };
        UIMenuItem blackOut = new UIMenuItem("Enable Black Out", "");
        uimenu.AddItem(blackOut);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == blackOut)
            {
                World.Blackout = true;
                BigMessageThread.MessageInstance.ShowSimpleShard("Black Out", "Enabled");
            }
        };
        UIMenuItem blackOutDisable = new UIMenuItem("Disable Black Out", "");
        uimenu.AddItem(blackOutDisable);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == blackOutDisable)
            {
                World.Blackout = false;
                BigMessageThread.MessageInstance.ShowSimpleShard("Black Out", "Dissabled");
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
        UIMenuItem giveArmor = new UIMenuItem("Give Armor", "");
        uimenu.AddItem(giveArmor);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == giveArmor)
            {
                Game.Player.Character.Armor = 100;
            }
        };
        UIMenuItem cleanBlood = new UIMenuItem("Clear Blood", "");
        uimenu.AddItem(cleanBlood);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == cleanBlood)
            {
                Game.Player.Character.ClearBloodDamage();
            }
        };
        UIMenuItem rechargeSA = new UIMenuItem("Refill Special Ability", "");
        uimenu.AddItem(rechargeSA);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == rechargeSA)
            {
                Game.Player.RefillSpecialAbility();
            }
        };
        UIMenuItem playerSuicide = new UIMenuItem("Kill Yourself", "");
        uimenu.AddItem(playerSuicide);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == playerSuicide)
            {
                Game.Player.Character.Kill();
            }
        };
        UIMenuItem pauseGameClock = new UIMenuItem("Pause Game Clock", "");
        uimenu.AddItem(pauseGameClock);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == pauseGameClock)
            {
                World.IsClockPaused = true;
            }
        };
        UIMenuItem unpauseGameClock = new UIMenuItem("Unpause Game Clock", "");
        uimenu.AddItem(unpauseGameClock);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == unpauseGameClock)
            {
                World.IsClockPaused = false;
            }
        };
        UIMenuItem fivestarWantedLevel = new UIMenuItem("Instant 5 Stars Wanted Level", "");
        uimenu.AddItem(fivestarWantedLevel);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == fivestarWantedLevel)
            {
                Game.Player.WantedLevel = 5;
            }
        };
        UIMenuItem fourStarWantedLevel = new UIMenuItem("4 Star Wanted Level", "");
        uimenu.AddItem(fourStarWantedLevel);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == fourStarWantedLevel)
            {
                Game.Player.WantedLevel = 4;
            }
        };
        UIMenuItem threeStarWantedLevel = new UIMenuItem("3 Star Wanted Level", "");
        uimenu.AddItem(threeStarWantedLevel);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == threeStarWantedLevel)
            {
                Game.Player.WantedLevel = 3;
            }
        };
        UIMenuItem twoStarWantedLevel = new UIMenuItem("2 Star Wanted Level", "");
        uimenu.AddItem(twoStarWantedLevel);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == twoStarWantedLevel)
            {
                Game.Player.WantedLevel = 2;
            }
        };
        UIMenuItem oneStarWantedLevel = new UIMenuItem("1 Star Wanted Level", "");
        uimenu.AddItem(oneStarWantedLevel);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if(item == oneStarWantedLevel)
            {
                Game.Player.WantedLevel = 1;
            }
        };
        UIMenuItem removeWantedLevel = new UIMenuItem("Remove Wanted Level", "");
        uimenu.AddItem(removeWantedLevel);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int idex)
        {
            if (item == removeWantedLevel)
            {
                Game.Player.WantedLevel = 0;
            }
        };
        UIMenuItem godMode = new UIMenuItem("God Mode", "");
        uimenu.AddItem(godMode);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if(item == godMode)
            {
                Game.Player.Character.IsInvincible = true;
            }
        };
        UIMenuItem godModeRemoval = new UIMenuItem("Remove God Mode", "");
        uimenu.AddItem(godModeRemoval);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == godModeRemoval)
            {
                Game.Player.Character.IsInvincible = false;
            }
        };
        UIMenuItem autoSaveGame = new UIMenuItem("Auto Save Game", "");
        uimenu.AddItem(autoSaveGame);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if(item == autoSaveGame)
            {
                Game.DoAutoSave();
            }
        };
        UIMenuItem nightVision = new UIMenuItem("Enable Night Vision", "");
        uimenu.AddItem(nightVision);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if(item == nightVision)
            {
                Game.IsNightVisionActive = true;
            }
        };
        UIMenuItem nightVisionDisable = new UIMenuItem("Disable Night Vision", "");
        uimenu.AddItem(nightVisionDisable);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == nightVisionDisable)
            {
                Game.IsNightVisionActive = false;
            }
        };
        UIMenuItem PoliceIgnorePlayer = new UIMenuItem("Enable Police Ignore Player", "");
        uimenu.AddItem(PoliceIgnorePlayer);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if(item == PoliceIgnorePlayer)
            {
                Game.Player.IgnoredByPolice = true;
                BigMessageThread.MessageInstance.ShowSimpleShard("Police Ignore Player", "Enabled");
            }
        };
        UIMenuItem DisablePoliceIgnorePlayer = new UIMenuItem("Disable Police Ignore Player", "");
        uimenu.AddItem(DisablePoliceIgnorePlayer);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == DisablePoliceIgnorePlayer)
            {
                Game.Player.IgnoredByPolice = false;
                BigMessageThread.MessageInstance.ShowSimpleShard("Police Ignore Player", "Disabled");
            }
        };
        UIMenuItem enableRandomEvent = new UIMenuItem("Enable Random Events", "");
        uimenu.AddItem(enableRandomEvent);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if(item == enableRandomEvent)
            {
                Game.IsRandomEventActive = true;
                BigMessageThread.MessageInstance.ShowSimpleShard("Enable Random Events", "Enabled!");
            }
        };
        UIMenuItem disableRandomEvent = new UIMenuItem("Disable Random Events", "");
        uimenu.AddItem(disableRandomEvent);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == disableRandomEvent)
            {
                Game.IsRandomEventActive = false;
                BigMessageThread.MessageInstance.ShowSimpleShard("Disable Random Events", "Disabled!");
            }
        };
        UIMenuItem tenGrand = new UIMenuItem("Give $10,000", "");
        uimenu.AddItem(tenGrand);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            if (item == tenGrand)
            {
                Game.Player.Money += 10000;
                BigMessageThread.MessageInstance.ShowSimpleShard("Money", "You have been given $10,000");
            }
        };
    }

    #endregion

    #region //Radio Station Menu //
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
    }
    #endregion

    #region // Animal Menu //
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
        UIMenuItem crow = new UIMenuItem("Crow", "");
        uimenu.AddItem(crow);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == crow;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_CROW");
            }
        };
        UIMenuItem deer = new UIMenuItem("Deer", "");
        uimenu.AddItem(deer);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == deer;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_DEER");
            }
        };
        UIMenuItem dolphin = new UIMenuItem("Dolphin", "");
        uimenu.AddItem(dolphin);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == dolphin;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_DOLPHIN");
            }
        };
        UIMenuItem fish = new UIMenuItem("Fish", "");
        uimenu.AddItem(fish);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == fish;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_FISH");
            }
        };
        UIMenuItem hammerShark = new UIMenuItem("Hammer Shark", "");
        uimenu.AddItem(hammerShark);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == hammerShark;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_SHARKHAMMER");
            }
        };
        UIMenuItem chickenHen = new UIMenuItem("Hen", "");
        uimenu.AddItem(chickenHen);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == chickenHen;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_HEN");
            }
        };
        UIMenuItem humbackWhale = new UIMenuItem("Humpback Whale", "");
        uimenu.AddItem(humbackWhale);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == humbackWhale;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_HUMPBACK");
            }
        };
        UIMenuItem shamuWhale = new UIMenuItem("Killer Whale", "");
        uimenu.AddItem(shamuWhale);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == shamuWhale;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_KILLERWHALE");
            }
        };
        UIMenuItem pigeon = new UIMenuItem("Pigeon", "");
        uimenu.AddItem(pigeon);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == pigeon;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_PIGEON");
            }
        };
        UIMenuItem pugDog = new UIMenuItem("Pug", "");
        uimenu.AddItem(pugDog);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == pugDog;
            if (flag)
            {
                Game.Player.ChangeModel("A_C_PUG");
            }
        };
    }
    #endregion //

    #region // Prop Weapons //
    public void PropWeaponMenu(UIMenu menu)
    {
        var props = this._menuPool.AddSubMenu(menu, "Prop Weapons");
        for (int i = 0; i < 1; i++) ;
        var newprops = new UIMenuItem("Give Props", "");
        props.AddItem(newprops);
        props.OnItemSelect += (sender, item, index) =>
        {
            if (item == newprops)
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
            }
        };
    }
    #endregion

    #region // Credits //

    public void _credits(UIMenu menu)
    {
        UIMenu uimenu = this._menuPool.AddSubMenu(menu, "Credits Section");
        for (int i = 0; i < 1; i++)
        {
        }
        UIMenuItem credits = new UIMenuItem("Credits", "");
        uimenu.AddItem(credits);
        uimenu.OnItemSelect += delegate (UIMenu sender, UIMenuItem item, int index)
        {
            bool flag = item == credits;
            if (flag)
            {
                BigMessageThread.MessageInstance.ShowSimpleShard("CREDITS", "AbelGaming's NativeUI Menu Template");
            }
        };
    }
    #endregion

    #region // Menu Setup //
    public SimplePedMenu()
    {
        this._menuPool = new MenuPool();
        UIMenu mainMenu = new UIMenu("~o~Simple Ped Menu", "~b~Mod ~g~by~w~ ~r~JonJonGames ~y~v2.3");
        this._menuPool.Add(mainMenu);
        this.PlayerModelMenu(mainMenu);
        this.VehicleMenu(mainMenu);
        this.WeaponMenu(mainMenu);
        this.AnimalMenu(mainMenu);
        this.RadioStationMenu(mainMenu);
        this.OptionsMenu(mainMenu);
        this.MPAnimationsMenu(mainMenu);
        this.PropWeaponMenu(mainMenu);
        this._credits(mainMenu);
        this._menuPool.RefreshIndex();
        this.config = ScriptSettings.Load("//scripts//SimplePedMenu.ini");
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
            }
        };
    }
    #endregion
}