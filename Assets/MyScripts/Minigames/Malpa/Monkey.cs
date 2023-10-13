using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField]
    private float scaleY = 1f;

    private float scaleMultiplier = 1f;

    public GameObject gameManager;

    public Sprite spriteHappy;
    public Sprite spriteAngry;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(scaleY<= 0.9f)
       {
            scaleMultiplier = 1f;
       }else if (scaleY >= 1.1f)
       {
           scaleMultiplier = -1f;
       }

        scaleY += 0.1f * scaleMultiplier * Time.deltaTime;

        transform.position = new Vector3(0f, scaleY -1f, 0f);

        if (gameManager.GetComponent<MonkeGamaManager>().angryness > 50f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteAngry;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteHappy;
        }
    }
}
