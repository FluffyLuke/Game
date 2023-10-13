using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnBricks : MonoBehaviour
{
    public GameObject[] bricksList;

    public int amountY = 7;
    public int amountX = 7;

    [SerializeField]
    public bool holdingBrick = false;

    public TextMeshProUGUI mainText;

    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        for(float i = 0; i < amountY; i++)
        {
            for(float j = 0; j < amountX; j++)
            {
                Vector2 spawnpPos = new Vector2((j * 2.65f) - 8f, (i*1.4f ) - 3.65f);
                Instantiate(bricksList[(int)Random.Range(0, bricksList.Length)], spawnpPos, Quaternion.identity);
            }
        }

        StartCoroutine(firstWait());
        mainText.text = "Napraw mur przeciagajac cegly";
    }

    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("BrickConPoint").Length == 0 && started)
        {
            StartCoroutine(winRoutine());
        }

        if (started)
        {
            mainText.alpha -= 1f * Time.deltaTime;
        }
        else
        {
            mainText.alpha = 1f;
        }
    }

    IEnumerator firstWait()
    {
        yield return new WaitForSeconds(5);

        started = true;
    }

    IEnumerator winRoutine()
    {
        started = false;
        mainText.text = "Brawo! Udalo Ci sie naprawie mur!";
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("MainGame");
    }
}
