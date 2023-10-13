using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YearCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [ SerializeField ]
    private StatsObject statsObject;
    [ SerializeField ]
    private TMP_Text text;
    private void Start()
    {
        this.text.text = "ROK: " + statsObject.Year.ToString();
        StatsObject.dataUpdated += UpdateCounter;
    }

    private void UpdateCounter()
    {
        this.text.text = "ROK: " + statsObject.Year.ToString();
    }
}
