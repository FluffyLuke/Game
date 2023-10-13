using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy1;

    Vector2 spawnPos;

    public int enemyAmount = 3;

    public GameObject gameManager;

    public TextMeshProUGUI mainText;

    private bool started = false;

    public string[] teksty = { "Umarles, sprobuj ponownie!", "Umarles, nie poddawaj sie!", "Umarles, ale to nie koniec, spróbuj ponownie!" };

    private int wave = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(spawnEnemy());
        StartCoroutine(firstWait());

        mainText.text = "Musisz nas obronic, w Tobie ostatnia nadzieja.";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<TimerTDS>().time >= 30f)
        {
            StopCoroutine(spawnEnemy());
            StopCoroutine(firstWait());

            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                StartCoroutine(winRoutine());
            }
        }

        if(started)
        {
            mainText.alpha -= 1f * Time.deltaTime;
        }
        else
        {
            mainText.alpha = 1f;

            foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemy);
            }
        }

    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(6.2f);

        for (int i = 0; i < wave; i++)
        {
            spawnPos = new Vector2(Random.Range(-9f, 9f), 4.5f);
            Instantiate(enemy1, spawnPos, Quaternion.identity);
        }
        wave += 1;

        StartCoroutine(spawnEnemy());
    }

    IEnumerator firstWait()
    {
        yield return new WaitForSeconds(5);
        started = true;
        StartCoroutine(spawnEnemy());
        gameManager.GetComponent<TimerTDS>().startTimer();
    }

    public void Died()
    {
        StopAllCoroutines();
        gameManager.GetComponent<TimerTDS>().time = 0f;
        mainText.text = teksty[Random.Range(0, 3)];
        StartCoroutine(firstWait());
        started = false;
        wave = 1;
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        foreach (var blood in GameObject.FindGameObjectsWithTag("blood"))
        {
            Destroy(blood);
        }

        foreach (var bullet in GameObject.FindGameObjectsWithTag("PlayerBullet"))
        {
            Destroy(bullet);
        }

        foreach (var bullet in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(bullet);
        }
    }

    IEnumerator winRoutine()
    {
        StopCoroutine(spawnEnemy());
        started = false;
        mainText.text = "Brawo! Pokonales wszystkich przeciwnikow!";
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("MainGame");
    }
}
