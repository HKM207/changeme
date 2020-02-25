﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hauke
{
    public static void ScrapyardClick()  ///INGAME UI
    {
        int random = Random.Range(0, 101);
        int[] dropchances = new int[2] { 65, 85 };

        Variables.resScraps = Variables.resScraps + (1 * Variables.clickMultiplier);

        if (random >= dropchances[0])
        {
            Variables.resPlastics = Variables.resPlastics + (1 * Variables.clickMultiplier);
        }
        if (random >= dropchances[1])
        {
            Variables.resElectronics = Variables.resElectronics + (1 * Variables.clickMultiplier);
        }
    }

    public static void ScrapyardWorker()
    {
        if (Variables.workerTick == 0)
        {
            Variables.workerTick = Variables.tickCounter;
        }
        if (Variables.timeInTicks >= Variables.workerTick)
        {
            int random = Random.Range(0, 101);
            int[] dropchances = new int[2] { 55, 75 };

            Variables.resScraps = Variables.resScraps + (1 * Variables.scrapYardCollectorMultiplier);

            if (random >= dropchances[0])
            {
                Variables.resPlastics = Variables.resPlastics + (1 * Variables.scrapYardCollectorMultiplier);
            }
            if (random >= dropchances[1])
            {
                Variables.resElectronics = Variables.resElectronics + (1 * Variables.scrapYardCollectorMultiplier);
            }
            Variables.workerTick += 1;
        }
    }

    public static void ScrapYardWorkerMultiplierCalculation()
    {
        if (Variables.scrapYardCollector >= 1)
        {
            Variables.scrapYardCollectorMultiplier = Variables.startScrapYardCollectorMultiplier * Variables.scrapYardCollector;
        }
    }

    public static void Factory()
    {
        if (Variables.engineProductionRatio < Variables.startEngineProductionRatio &&
            Variables.tireProductionRatio < Variables.startTireProductionRatio &&
            Variables.frameProductionRatio < Variables.startFrameProductionRatio)
        {
            Variables.engineProductionRatio = Variables.startEngineProductionRatio;
            Variables.tireProductionRatio = Variables.startTireProductionRatio;
            Variables.frameProductionRatio = Variables.startFrameProductionRatio;
        }
        if (Variables.factoryTick == 0)
        {
            Variables.factoryTick = Variables.tickCounter;
        }
        if (Variables.timeInTicks >= Variables.factoryTick)
        {
            Part partEngine = new Part(SortOfPart.Engine);
            ProducePart(partEngine);
            Part partFrame = new Part(SortOfPart.Frame);
            ProducePart(partFrame);
            Part partTire = new Part(SortOfPart.Tire);
            ProducePart(partTire);
            Variables.factoryTick += 1;
        }
    }
    public static void ProducePart(Part part)
    {
        if (Variables.resScraps >= part.requiredScrap &&
            Variables.resPlastics >= part.requiredPlastics &&
            Variables.resElectronics >= part.requiredElectronics)
        {
            if (part.sort == SortOfPart.Engine)
            {
                Variables.partEngines = Variables.partEngines + (1 * Variables.engineProductionRatio);

                Variables.resScraps = Variables.resScraps - (part.requiredScrap * Variables.engineProductionRatio);
                Variables.resPlastics = Variables.resPlastics - (part.requiredPlastics * Variables.engineProductionRatio);
                Variables.resElectronics = Variables.resElectronics - (part.requiredElectronics * Variables.engineProductionRatio);
            }
            else if (part.sort == SortOfPart.Frame)
            {
                Variables.partFrames = Variables.partFrames + (1 * Variables.frameProductionRatio);

                Variables.resScraps = Variables.resScraps - (part.requiredScrap * Variables.frameProductionRatio);
                Variables.resPlastics = Variables.resPlastics - (part.requiredPlastics * Variables.frameProductionRatio);
                Variables.resElectronics = Variables.resElectronics - (part.requiredElectronics * Variables.frameProductionRatio);
            }
            else if (part.sort == SortOfPart.Tire)
            {
                Variables.partTires = Variables.partTires + (1 * Variables.tireProductionRatio);

                Variables.resScraps = Variables.resScraps - (part.requiredScrap * Variables.tireProductionRatio);
                Variables.resPlastics = Variables.resPlastics - (part.requiredPlastics * Variables.tireProductionRatio);
                Variables.resElectronics = Variables.resElectronics - (part.requiredElectronics * Variables.tireProductionRatio);
            }
        }
    }

    public static void FactoryCostsCalculation()
    {
        if (Variables.factoryCost < Variables.startFactoryCost)
        {
            Variables.factoryCost = Variables.startFactoryCost;
        }
        if (Variables.factoryUpgrades < 4 && Variables.playerMoney >= Variables.factoryCost)
        {
            Variables.factoryCost = Variables.factoryCost * (1 + Variables.factoryUpgrades);
        }
        else if (Variables.playerMoney >= Variables.factoryCost)
        {
            Variables.factoryCost = Variables.factoryCost * (1 + Variables.factoryUpgrades / 2);
        }
    }

    //-------------------Hauke-Test---------------------------------
    public static void ResearchFacilityUpgrades()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && Variables.playerMoney >= Variables.clickMultiplierUpgradeCosts)
        {
            Variables.playerMoney = Variables.playerMoney - Variables.clickMultiplierUpgradeCosts;
            Variables.clickMultiplierUpgrades++;
            Variables.clickMultiplier = Variables.clickMultiplier * Variables.clickMultiplierUpgrades;

            Variables.clickMultiplierUpgradeCosts = Variables.clickMultiplierUpgradeCosts * (Variables.clickMultiplierUpgrades * 4);
        }
    }

    public static void ResearchFacilityUpgradeCostCalculations()
    {
        if (Variables.clickMultiplierUpgradeCosts <= Variables.clickMultiplierUpgradeStartCosts)
        {
            Variables.clickMultiplierUpgradeCosts = Variables.clickMultiplierUpgradeStartCosts;
        }
    }
    //-------------------Hauke-Test---------------------------------
}
