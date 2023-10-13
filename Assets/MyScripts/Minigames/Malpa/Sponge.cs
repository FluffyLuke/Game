using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sponge : MonoBehaviour
{
    public ParticleSystem spongeParticle;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monkey")
        {
            GetComponent<SpriteRenderer>().enabled = true;
            UnityEngine.Cursor.visible = false;
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dirt"))
        {
            if(Input.GetMouseButtonDown(0)){
                spongeParticle.Play();
                // collision.gameObject.GetComponent<Dirt>().health -= 34f;
                // Debug.Log(collision.gameObject.GetComponent<Dirt>().health);
            }
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Monkey")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            UnityEngine.Cursor.visible = true;
        }
    }
}
