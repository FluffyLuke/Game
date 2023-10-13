using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomString : MonoBehaviour
{
    public GameObject typer;

    public string[] strings;

    public string finalString;

    void Start()
    {
        if (strings.Length == 0)
        {
            finalString = "Tekst";
        }

        losString();
    }

    public void losString()
    {
        finalString = strings[Random.Range(0, strings.Length - 1)];

        typer.GetComponent<Typer>().textToType = finalString;
        typer.GetComponent<Typer>().SetCurrentText();
    }
}
