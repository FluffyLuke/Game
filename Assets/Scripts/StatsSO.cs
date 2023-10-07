using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/StatsObject", order = 1)]
public class StatsObject : ScriptableObject
{
    //General Stats
    [ SerializeField ]
    public int year;

    //CHARACTER STATS
    [ SerializeField ]
    public int gold;
    [ SerializeField ]
    public int age;
    [ SerializeField ]
    private int yearOfDeath = 40;

    public int YearOfDeath => yearOfDeath;
}
