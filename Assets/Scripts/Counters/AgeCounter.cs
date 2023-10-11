using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [ SerializeField ]
    private StatsObject statsObject;
    [ SerializeField ]
    private TMP_Text text;
    private void Start()
    {
        this.text.text = statsObject.Age.ToString();
        StatsObject.dataUpdated += UpdateCounter;
    }

    private void UpdateCounter()
    {
        this.text.text = "Wiek: " + statsObject.Age.ToString();
    } 
}
