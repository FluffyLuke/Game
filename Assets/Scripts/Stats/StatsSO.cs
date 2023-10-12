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

    public static event DataUpdated dataUpdated;
    //General Stats
    [ SerializeField ]
    private int year;
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

    public int EndGame => endGame;
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
            popularity = value;
            dataUpdated?.Invoke(); 
        }
    }

    public int MaxPopularity => maxPopularity;
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
    [CreateAssetMenu(fileName = "StatsChanges", menuName = "ScriptableObjects/StatsChanges", order = 5)]
    public class StatChanges : StatsObject
    {
        public string eventStatChangesText;
        public string buttonText;
        public List<Events.Event> additionalEvents;
        public int costGold;
        public int costActionPoints;
        public bool UpdateStats(StatsObject stats, List<Events.Event> events)
        {
            if (stats.ActionPoints < costActionPoints)
            {
                return false;
            }
            if (stats.Gold < costGold)
            {
                return false;
            }
            foreach (var e in this.Effects)
            {
                stats.Effects.Add(e);
            }
            foreach (var e in this.Achievements)
            {
                stats.Achievements.Add(e);
            }
            foreach (var e in additionalEvents)
            {
                events.Add(e);
            }
            stats.Popularity += Popularity;
            stats.Gold += Gold;
            stats.GoldIncome += GoldIncome;
            stats.ActionPoints += ActionPoints;
            stats.ActionPoints -= costActionPoints;
            stats.ActionPoints -= costGold;
            return true;
        }
    }
}