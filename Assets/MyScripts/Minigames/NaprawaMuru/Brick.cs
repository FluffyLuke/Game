using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool holding;
    private bool beenHolding = false;

    public GameObject brickConnectPoint;

    public bool placed = false;

    void Start()
    {
        int canSpawn;
        canSpawn = Random.Range(1, 5);
        if(transform.position.y < -3f)
        {
            canSpawn = Random.Range(1, 10);
        }
        if(canSpawn == 1 && !gameObject.GetComponent<Rigidbody2D>())
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;

            Instantiate(brickConnectPoint, gameObject.transform.position, Quaternion.identity);
        }

        holding = GameObject.FindWithTag("GameController").GetComponent<SpawnBricks>().holdingBrick;
    }

    // Update is called once per frame
    void Update()
    {
        if (holding && !placed)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!placed)
        {
            if (collision.tag == "Ywall" && rb != null)
            {
                rb.velocity = Vector2.zero;
                // rb.gravityScale = 0;

                rb.isKinematic = true;
            }
        }
    }

    private void OnMouseOver()
    {
        if (!placed)
        {
            if (Input.GetMouseButton(0) && rb != null && holding == false)
            {
                holding = true;

                beenHolding = true;
            }
            else
            {
                if (beenHolding)
                {
                    if (!holding)
                    {
                        rb.isKinematic = false;
                        if (transform.position.y < -4f)
                        {
                            transform.position = new Vector2(transform.position.x, -4f);
                            beenHolding = false;
                        }
                    }
                    holding = false;
                }
            }
        }
    }
}
