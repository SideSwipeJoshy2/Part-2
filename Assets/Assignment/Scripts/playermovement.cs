using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    


public class playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 move;
    Vector2 destination;
    bool clickSelf = false;
    public float speed = 3;
    public float stamina;
    public float maxStam = 5;
    bool noStam = false;
    // Start is called before the first frame update
    void Start()
    {//setup for player and health
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stamina = maxStam;
      
    }

    private void FixedUpdate()
    {
        if (noStam) return; //checks if the player has no stamina and if so prevents the player from doing anything except refill stamina
        move = destination - (Vector2)transform.position;
        if (move.magnitude < 0.1)
        {
            move = Vector2.zero;
        }
        rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);



    }

    // Update is called once per frame
    void Update()
    {
        if (noStam) return;
        if (Input.GetMouseButtonDown(0) && !clickSelf && !EventSystem.current.IsPointerOverGameObject())//mouse movement
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("movement", move.magnitude);//speed boost
        if (Input.GetKey(KeyCode.Space)) 
            {
            Random.Range(speed = 5, 10);
            animator.SetTrigger("boost");
        }
    }

    private void OnMouseDown()//debug help
    {
        if (noStam) return;
        clickSelf = true;
        SendMessage("stamDrain", 1);

    }


    private void OnMouseUp()
    {
        clickSelf = false;


    }


    public void stamDrain(float lowStam)//checks player's health and if it is too low they are unable to move
    {
        stamina -= lowStam;
        stamina = Mathf.Clamp(stamina, 0, maxStam);
        print(stamina);
        if (stamina <= 0)
        {
            noStam = true;
            animator.SetTrigger("death");

        }
        else//if player has hp they can continue playing
        {
            noStam = false;
            animator.SetTrigger("loseStam");
        }
    }

}

