using System.Collections;
using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 50f;

    Vector3 vector;

    public GameObject aimer;

    private void Start()
    {
        // vector = new Vector3(0.1f, -0.05f, 0);
    }

    private void Update()
    {
        /*if (transform.position.x >= 4f)
        {
            vector = new Vector3(-0.1f, 0.05f, 0f);
        }

        if (transform.position.x <= -4f)
        {
            vector = new Vector3(0.1f, -0.05f, 0f);
        }

        transform.position = transform.position + vector * speed * Time.deltaTime;*/

        transform.position = new Vector2(aimer.transform.position.x * 1.5f, transform.position.y);
    }
}
