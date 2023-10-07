using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [ SerializeField ]
    public StatsObject _statsObject;
    [ SerializeField ]
    private int round;
    public void OnEnable()
    {
        round = 1;
        _statsObject.age = 10;
        _statsObject.gold = 100;
    }
    public void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        
    }
    
    public void StartEndRound()
    {
        
    }
}
