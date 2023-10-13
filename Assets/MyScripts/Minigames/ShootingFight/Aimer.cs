using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aimer : MonoBehaviour
{
    public GameObject target;

    public float speed = 1f;

    Vector3 vector;

    public bool isColliding = false;

    public bool shot = false;

    public TextMeshProUGUI resultText;

    public float difficulty = 1f;

    public TextMeshProUGUI destroyText;

    private bool started = false;

    public StatsObject stats;

    void Start()
    {
        target.transform.localScale = 
            new Vector3( 1f / difficulty, target.transform.localScale.y, target.transform.localScale.z);
    }

    void Update()
    {
        if (!shot)
        {
            if (transform.position.x >= 2.5)
            {
                vector = new Vector3(-0.1f, 0, 0);
            }

            if (transform.position.x <= -2.5)
            {
                vector = new Vector3(0.1f, 0, 0);
            }

            transform.position = transform.position + vector * speed * Time.deltaTime;
        }


        if (Input.GetButtonDown("Jump"))
        {
            shot = true;

            if(isColliding && !started)
            {
                resultText.text = "Udalo Ci sie pokonac zlodzieja - nie tracisz pieniedzy!";
                StartCoroutine(winRoutine());
                destroyText.text = "";
                started = false;
            }
            else
            {
                if(!started)
                {
                    resultText.text = "Nie udalo Ci sie pokonac zlodzieja - tracisz pieniadze!";
                    StartCoroutine(winRoutine());
                    destroyText.text = "";
                    started = false;

                    stats.Gold -= 300;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }

    IEnumerator winRoutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainGame");
    }
}
