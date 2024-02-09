using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Transform spawn;
    public GameObject ballPrefab;
    public float speed = 3;
    float timeRemaining = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 5, SendMessageOptions.DontRequireReceiver);
        

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(1 * speed * Time.deltaTime, 0 ,0);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(ballPrefab, spawn.position, spawn.rotation);
           
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }


    }
}
