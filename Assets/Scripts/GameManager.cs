using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [ SerializeField ]
    public StatsObject statsObject;

    [SerializeField] private int round;
    private void OnEnable()
    {
        StartGame();
    }
    
    public void StartGame()
    {
        round = 1;
        statsObject.Age = 10;
        statsObject.Gold = 100;
        statsObject.Year = 1237;
    }
    public void StartTurn()
    {
        StartRound();
    }

    public void StartRound()
    {
        print("Round starting new round!");
    }
    
    public void EndRound()
    {
        print("Round has ended!");
        round += 1;
        statsObject.addAge(1);
        statsObject.addYear(1);
    }

    public void Test()
    {
        print("TESTING!");
        round += 1;
        statsObject.addAge(1);
        statsObject.addYear(1);
        statsObject.addGold(100);
    }
}
