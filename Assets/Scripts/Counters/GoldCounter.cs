using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoldCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [ SerializeField ]
    private StatsObject statsObject;
    [ SerializeField ]
    private TMP_Text text;
    private void Start()
    {
        this.text.text = "Pieniądze: " + statsObject.Gold.ToString();
        StatsObject.dataUpdated += UpdateCounter;
    }

    private void UpdateCounter()
    {
        this.text.text = "Pieniądze: " + statsObject.Gold.ToString();
    }
}
