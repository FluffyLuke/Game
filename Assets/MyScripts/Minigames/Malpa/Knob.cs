using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    public float temperature = 1f;

    public float temperatureMultiplier = 1f;

    private float rotation = 0f;

    public GameObject gameManager;

    private float waterTemp;

    public GameObject knobCursor;

    private void OnMouseOver()
    {
        waterTemp = gameManager.GetComponent<MonkeGamaManager>().waterTemperature;
        knobCursor.GetComponent<SpriteRenderer>().enabled = true;
        Cursor.visible= false;

        if (Input.GetMouseButton(0))
        {
            if(temperatureMultiplier > 0 && waterTemp < gameManager.GetComponent<MonkeGamaManager>().maxTemp)
            {
                ChangeTemp();
                
            }

            if(temperatureMultiplier < 0 && waterTemp > gameManager.GetComponent<MonkeGamaManager>().minTemp)
            {
                ChangeTemp();
            }
            
        }
    }

    private void OnMouseExit()
    {
        knobCursor.GetComponent<SpriteRenderer>().enabled = false;
        Cursor.visible = true;
    }

    private void ChangeTemp()
    {
        temperature += 10f * temperatureMultiplier * Time.deltaTime;

        rotation += -75f * Time.deltaTime;

        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}

