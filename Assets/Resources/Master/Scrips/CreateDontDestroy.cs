using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Gamestate
{
    ingame
}

public class CreateDontDestroy : MonoBehaviour
{
    private GameObject logic;
    private static CreateDontDestroy instance;
    public static Gamestate CurrentGamestate;
    public static bool isNewGame = true;

    private void Awake()
    {
        logic = this.gameObject;
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        CurrentGamestate = Gamestate.ingame; 
    }
    private void Update()
    {
        if (CurrentGamestate == Gamestate.ingame)
        {
            #region cheats
            if (Input.GetKeyDown(KeyCode.P))
            {
                Variables.playerMoney = Variables.playerMoney + 20000;
                Variables.playerMoneyTotel = Variables.playerMoneyTotel + 20000;

                Variables.resScraps = Variables.resScraps + 100;
                Variables.resPlastics = Variables.resPlastics + 100;
                Variables.resElectronics = Variables.resElectronics + 100;

            }
            #endregion
            Killian.LevelUpSystem(Variables.levelUpModifier);
            Tickrate();
            Calculations();
        }
        SaveGame();
        Malte.EscMenu();
    }
    private void AudioManager()
    {
        //if (CurrentGamestate == Gamestate.mainMenu)
        //{
        //    //play main menu music
        //}
        if (CurrentGamestate == Gamestate.ingame)
        {
            //play background music
        }
    }
    public void Tickrate()
    {
        Variables.timeInSek += Time.deltaTime;
        Variables.timeInTicks = Variables.timeInSek * 4;
        if (Variables.timeInTicks >= Variables.tickCounter && Variables.scrapYardCollector == 0)
        {
            Variables.tickCounter += 1;
        }
    }
    public void Calculations()
    {
        Hauke.ScrapyardWorker();
        Hauke.ResearchFacilityUpgradeCostCalculations();
    }
    #region Save
    public void NewGame()
    {
        CurrentGamestate = Gamestate.ingame;
        Malte.LoadNewGame();
    }
    public void LoadGame()
    {
        if (Malte.LoadGameFromSave())
        {
            CurrentGamestate = Gamestate.ingame;
            Malte.LoadGame();
        }
    }
    public void SaveGame()
    {
        if (CurrentGamestate == Gamestate.ingame && Input.GetKeyDown(KeyCode.L))
        {
            Malte.SaveGame();
        }
    }
    #endregion
}
public class Variables
{
    public static int totalClicks;
    public static int clicks = 0;

    public const int Poolsize = 100;

    public static GameObject mainUI;
    public static GameObject carUI;
    public static GameObject scrollListCars;
    public static Car[] cars;
   
    public static bool isIngame = false;
    public static bool isPaused = false;

    public static float resScraps;
    public static float resElectronics;
    public static float resPlastics;

    public static int playerLevel = 1;
    public static float playerExperience = 0;
    public static float expNeededForLvlUp = 5000;
    public const int levelUpModifier = 3;

    public static float playerMoney;
    public static float playerMoneyTotel;
    public static int soldCars = 0;

    public static float playerGems;
    public static int totelResets;

    public static float clickMultiplier = 1;
    public static float carValueMultiplier = 1;

    public static float timeInSek;
    public static int tickCounter = 1;
    public static float timeInTicks;
    public static int workerTick = 0;

    public static float workerCost = 5000;
    public static float scrapYardCollectorMultiplier;
    public static int scrapYardCollector;
    public static float startScrapYardCollectorMultiplier = 0.125f;

    public static bool isResearchFacilityActiv = false;

    public static float clickMultiplierUpgradeStartCosts = 2000;
    public static float clickMultiplierUpgradeCosts;
    public static int clickMultiplierUpgrades;

    public static ButtonClass[] buttonClasses;
}