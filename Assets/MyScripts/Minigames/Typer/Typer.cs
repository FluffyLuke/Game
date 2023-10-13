using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    // text bank

    public TextMeshProUGUI textToTypeObject = null;
    public TextMeshProUGUI typedTextObject = null;

    public string remainingText = string.Empty;
    public string textToType = "Do gospodyniej Ciebie z³a lwica w ogromnej jaskini Nie urodzi³a, moja gospodyni,Kochanek, Mi³oœæ Ani swym mlekiem tygrys napawa³a; Gdzie¿eœ siê w¿dy tak sroga uchowa³a, ¯e nie chcesz baczyæ na me powolnoœci Ani miê wspomóc w mej wielkiej trudnoœci? O któr¹ sama¿eœ miê przyprawi³a, ¯e chodzê ma³o nie tak jako wi³a.";

    public string sceneName = "Malpa";

    public string typedText = string.Empty;

    public ParticleSystem typingEffect;

    public GameObject pen;

    public GameObject timer;

    public Camera cam;

    public bool end = false;

    public StatsObject stats;

    // Start is called before the first frame update
    void Start()
    {
        typedTextObject.text = typedText;

        textToTypeObject.text = textToType;

        SetCurrentText();
    }

    // Update is called once per frame
    void Update()
    {
        typedTextObject.text = typedText;

        textToTypeObject.text = textToType;
        
        CheckInput();

        if (end)
        {
            cam.orthographicSize -= 1.6f * Time.deltaTime;
            typedTextObject.transform.localScale += new Vector3(0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0f);
            textToTypeObject.transform.localScale += new Vector3(0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0f);
        }
    }

    public void SetCurrentText()
    {
        // get text from bank

        SetRemainingText(textToType);
    }

    private void SetRemainingText(string newString)
    {
        remainingText = newString;
        typedTextObject.text = typedText;
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            AddLetter();

            if (IsWordComplete())
            {
                timer.GetComponent<Timer>().stopTimer();
                StartCoroutine(newScene()); 
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        if (remainingText.IndexOf(letter.ToLower()) == 0 || remainingText.IndexOf(letter.ToUpper()) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void AddLetter()
    {
        timer.GetComponent<Timer>().startTimer();

        typedText += remainingText[0];
        string newString = remainingText.Remove(0, 1);
        if (newString.Length > 0 && newString[0] == ' ')
        {
            newString = newString.Remove(0, 1);
            typedText += ' ';
            MovePen();
        }

        MovePen();

        SetRemainingText(newString);

    }

    private bool IsWordComplete()
    {
        return remainingText.Length == 0;
    }

    private void MovePen()
    {
        /*pen.transform.position = new Vector3(pen.transform.position.x + 0.2f, pen.transform.position.y, 0);
        if(pen.transform.position.x >= 6f)
        {
            pen.transform.position = new Vector3(-3f, pen.transform.position.y-1f, 0);
        }*/

        Quaternion randZRotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-75f, -85f));
        pen.transform.rotation = randZRotation;

        typingEffect.Play();
    }

    IEnumerator newScene()
    {
        end = true;

        int fame = 6;
        if(timer.GetComponent<Timer>().time < 15f)
        {
            fame = 6;
        }
        else if(timer.GetComponent<Timer>().time < 25f)
        {
            fame = 5;
        }
        else if (timer.GetComponent<Timer>().time < 35f)
        {
            fame = 4;
        }
        else if (timer.GetComponent<Timer>().time >= 35f)
        {
            fame = 3;
        }

        stats.Popularity += fame;

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(sceneName);
    }
}
