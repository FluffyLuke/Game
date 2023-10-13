using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickConnect : MonoBehaviour
{
    public GameObject brick;

    public ParticleSystem brickParticle;

    public AudioSource src;
    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BrickConPoint" && brick.GetComponent<Brick>().holding)
        {
            src.clip= clip;
            src.Play();

            brick.GetComponent<Brick>().placed = true;
            brick.GetComponent<Rigidbody2D>().isKinematic = true;
            brick.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            brick.GetComponent<SpriteRenderer>().sortingOrder = 1;

            Destroy(collision.gameObject);

            brickParticle.Play();
        }
    }
}
