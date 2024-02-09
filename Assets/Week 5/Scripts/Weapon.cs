using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Transform spawn;
    public GameObject axePrefab;
    float timer = 5;
    float speed = 3;
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
            Instantiate(axePrefab, spawn.position, spawn.rotation);
           
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }


    }
}

