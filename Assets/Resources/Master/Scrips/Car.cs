﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Car
{
    public string name;

    public int moneyValue = 500;
    public int expValue = 500;
    public int level;

    public int requiredEngines = 2;
    public int requiredTires = 4;
    public int requiredFrames = 2;

   
    public Car()
    {
        //SetValues();
    }
    public Car(int _level)
    {
        this.level = _level;
        SetValues();
    }

    public void SetValues()
    {
        //Balancing
        this.moneyValue = this.moneyValue * this.level;
        this.expValue = this.expValue * this.level;
        this.requiredEngines = this.requiredEngines * this.level;
        this.requiredTires = this.requiredTires * this.level;
        this.requiredFrames = this.requiredFrames * this.level;

    }

}
