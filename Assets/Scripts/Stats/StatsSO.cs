using System;
using System.Collections;
using System.Collections.Generic;
using Stats.Achievements;
using Stats.OtherStats;
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
    [ SerializeField ]
    private int popularity = 5;
    [ SerializeField ]
    private int maxPopularity = 100;
    [ SerializeField ]
    private List<OtherStat> other;
    [SerializeField] 
    private List<Achievement> achievements;
    public int YearOfDeath => yearOfDeath;

    public int Popularity
    {
        get => popularity;
        set => popularity = value;
    }

    public int MaxPopularity
    {
        get => maxPopularity;
    }

    public List<OtherStat> Other
    {
        get => other;
        set => other = value;
    }

    public List<Achievement> Achievements
    {
        get => achievements;
        set => achievements = value;
    }

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
}