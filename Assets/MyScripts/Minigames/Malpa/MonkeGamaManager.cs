using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonkeGamaManager : MonoBehaviour
{
    public float waterTemperature = 30f;

    public GameObject lowerKnob;
    public GameObject higherKnob;

    public float maxTemp = 60f;
    public float minTemp = 0f;

    public TextMeshProUGUI maxTempText;
    public TextMeshProUGUI minTempText;

    public Slider sliderTemp;

    public float requiredTemp;
    public TextMeshProUGUI requiredTempText;
    private bool coroutineStarted = false;

    public Slider sliderAngry;
    public float angryness = 0f;

    public TextMeshProUGUI mainText;

    private bool started = false;

    private bool canWin = true;
    private bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        canWin = true;
        maxTempText.text = ((int)Math.Round(maxTemp)).ToString() + "\u00B0C";
        minTempText.text = ((int)Math.Round(minTemp)).ToString() + "\u00B0C";

        requiredTemp = Mathf.Round(UnityEngine.Random.Range(minTemp, maxTemp));

        mainText.text = "Umyj malpke, jednoczesnie pilnujac temperatury wody.";

        Invoke("setStarted", 3f);

    }

    // Update is called once per frame
    void Update()
    {
        sliderTemp.value = waterTemperature;
        sliderAngry.value = angryness;

        if (waterTemperature <= minTemp && !won)
        {
            Restart();
            mainText.text = "Za niska temperatura, sprubuj ponownie";
        }

        if (waterTemperature >= maxTemp && !won)
        {
            Restart();
            mainText.text = "Za wysoka temperatura, sprubuj ponownie";
        }

        waterTemperature = lowerKnob.GetComponent<Knob>().temperature + higherKnob.GetComponent<Knob>().temperature;

        if (waterTemperature <= requiredTemp + 2f && waterTemperature >= requiredTemp - 2f)
        {
            if(angryness >= 0f)
            {
                angryness -= 25f * Time.deltaTime;
            }
            if(!coroutineStarted)
            {
                StartCoroutine(NewRequiredTemp());
                coroutineStarted = true;
            }
        }else
        {
            if (angryness <= 100f)
            {
                angryness += 7f * Time.deltaTime;
            }
            else
            {
                if (!won)
                {
                    Restart();
                    mainText.text = "Malpka sie zezloscila, sprobuj ponownie";
                }
            }

            if (coroutineStarted)
            {
                StopAllCoroutines();
                coroutineStarted = false;
            }
        }

        // Debug.Log(waterTemperature + "<=" + (requiredTemp + 2f) + "&&" + waterTemperature + ">=" + (requiredTemp - 2f));

        requiredTempText.text = requiredTemp.ToString() + "\u00B0C";


        if (started)
        {
            mainText.alpha -= 1f * Time.deltaTime;
        }
        else
        {
            mainText.alpha = 1f;
        }

        if(GameObject.FindGameObjectsWithTag("Dirt").Length == 0 && canWin) 
        {
            StartCoroutine(winRoutine());
        }
    }
    IEnumerator NewRequiredTemp()
    {
        yield return new WaitForSeconds(5);
        
        requiredTemp = Mathf.Round(UnityEngine.Random.Range((minTemp+5f), (maxTemp-5f)));
        coroutineStarted = false;
    }

    public void Restart()
    {
        StartCoroutine(RestartRoutine());
        started = false;
        canWin = false;
    }

    IEnumerator RestartRoutine()
    {
        yield return new WaitForSeconds(3);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void setStarted()
    {
        started = true;
    }

    IEnumerator winRoutine()
    {
        won = true;
        started = false;
        mainText.text = "Brawo! Udalo Ci sie umyc malpke!";
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("MainGame");
    }
}
