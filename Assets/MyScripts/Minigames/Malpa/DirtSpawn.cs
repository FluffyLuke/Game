using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtSpawn : MonoBehaviour
{
    public GameObject dirtPrefab;
    public GameObject dirtPrefab1;
    public float spawnRadius = 3.5f;

    public int dirtAmount = 10;

    void Start()
    {
        for(int i = 0; i < dirtAmount; i++)
        {
            int rand = Random.Range(0, 1);

            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            if(rand == 0)
            {
                GameObject dirt = Instantiate(dirtPrefab,
                    new Vector3(transform.position.x + randomPosition.x, transform.position.y + randomPosition.y, 0)
                    , Quaternion.identity);
                dirt.transform.parent = GameObject.FindGameObjectWithTag("Monkey").transform;
            }
            else
            {
                GameObject dirt = Instantiate(dirtPrefab1,
                    new Vector3(transform.position.x + randomPosition.x, transform.position.y + randomPosition.y, 0)
                    , Quaternion.identity);
                dirt.transform.parent = GameObject.FindGameObjectWithTag("Monkey").transform;
            }

        }
    }
}
