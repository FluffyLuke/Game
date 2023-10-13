using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionPoinsCounter : MonoBehaviour
{
    [ SerializeField ]
    private StatsObject statsObject;
    [ SerializeField ]
    private TMP_Text text;
    private void Start()
    {
        this.text.text = statsObject.ActionPoints.ToString();
        StatsObject.dataUpdated += UpdateCounter;
    }

    private void UpdateCounter()
    {
        this.text.text = statsObject.ActionPoints.ToString();
    }
}
