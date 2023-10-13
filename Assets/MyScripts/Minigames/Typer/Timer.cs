using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 0.0f;

    public TextMeshProUGUI timerText;

    private bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if (isStarted)
        {
            time += Time.deltaTime;

            timerText.text = $"Czas: {time.ToString("#")}s";
        }
    }

    public void startTimer()
    {
        isStarted = true;
    }

    public void stopTimer()
    {
        isStarted = false;
    }

}