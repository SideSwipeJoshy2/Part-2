using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
   public GameObject planePrefab;
    Vector3 spawn;
    public float timespawn;
    public float pretime;
    Vector2 y;
    // Start is called before the first frame update
    void Start()
    {
        spawn = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (timespawn < 0)
        {
            Instantiate(planePrefab, spawn, Quaternion.identity);
            timespawn = pretime;
        }
        else
        {
            timespawn -= Time.deltaTime;
        }
    }
}
