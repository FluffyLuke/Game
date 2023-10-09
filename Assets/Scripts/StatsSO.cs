using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/StatsObject", order = 1)]
public class StatsObject : ScriptableObject
{
    public delegate void DataUpdated();

    public static event DataUpdated dataUpdated;
    //General Stats
    [ SerializeField ]
    private int year;
    //CHARACTER STATS
    [ SerializeField ]
    private int gold;
    [ SerializeField ]
    private int age;
    [ SerializeField ]
    private int yearOfDeath = 40;

    public int YearOfDeath => yearOfDeath;
    
    private void UpdateData()
    {
        dataUpdated?.Invoke();
    }

    public int Year
    {
        get => year;
        set {
            year = value;
            dataUpdated?.Invoke(); 
        }
    }

    public int Gold
    {
        get => gold;
        set {
            gold = value;
            dataUpdated?.Invoke(); 
        }
    }

    public int Age
    {
        get => age;
        set {
            age = value;
            dataUpdated?.Invoke(); 
        }
    }

    public void addGold(int additionalGold)
    {
        this.gold += additionalGold;
        dataUpdated?.Invoke(); 
    }
    public void subtractGold(int ammount)
    {
        this.gold -= ammount;
        dataUpdated?.Invoke(); 
    }
    public void addYear(int additionalYear)
    {
        this.year += additionalYear;
        dataUpdated?.Invoke(); 
    }
    public void addAge(int additionalAge)
    {
        this.age += additionalAge;
        dataUpdated?.Invoke(); 
    }
    
}