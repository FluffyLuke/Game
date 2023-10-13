using System;
using System.Collections;
using System.Collections.Generic;
using Stats.OtherStats;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/StatsObject", order = 1)]
public class StatsObject : ScriptableObject
{
    public delegate void DataUpdated();

    public bool ifGameStarted;
    public static event DataUpdated dataUpdated;
    //General Stats
    [ SerializeField ]
    private int year;
    [ SerializeField ]
    public int round;
    [ SerializeField ]
    private int endGame;
    //CHARACTER STATS
    [ SerializeField ]
    private int gold;
    [ SerializeField ]
    private int goldIncome;
    [ SerializeField ]
    private int age;
    [ SerializeField ]
    private int popularity = 5;
    [ SerializeField ]
    private int maxPopularity = 100;
    [ SerializeField ] 
    private List<Achievement> achievements;
    [SerializeField] 
    private List<Effect> effects;
    [ SerializeField ]
    private int actionPoints;
    [ SerializeField ]
    private int startingActionPoints;

    public List<Achievement> Achievements1
    {
        get => achievements;
        set => achievements = value;
    }

    public int ActionPoints
    {
        get => actionPoints;
        set {
            actionPoints = value;
            dataUpdated?.Invoke(); 
        }
    }

    public int StartingActionPoints
    {
        get => startingActionPoints;
        set {
            startingActionPoints = value;
            dataUpdated?.Invoke(); 
        }
    }

    public int EndGame {
        get => endGame;
        set => goldIncome = value;
    }
    public int GoldIncome
        {
            get => goldIncome;
            set
            {
                goldIncome = value;
                dataUpdated?.Invoke(); 
            }
        }
    public int Popularity
    {
        get => popularity;
        set {
            if (!(popularity + value < 0))
            {
                popularity = value;
            }
            else
            {
                popularity = 1;
            }
            dataUpdated?.Invoke(); 
        }
    }

    public int MaxPopularity {
        get => maxPopularity;
        set => maxPopularity = value;
    }
    public List<Achievement> Achievements
    {
        get => achievements;
        set {
            achievements = value;
            dataUpdated?.Invoke(); 
        }
    }
    public List<Effect> Effects
    {
        get => effects;
        set {
            effects = value;
            dataUpdated?.Invoke(); 
        }
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
            if (!(gold + value < 0))
            {
                gold = value;
            }
            else
            {
                gold = 0;
            }
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