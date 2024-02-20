using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
    


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
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stamina = maxStam;
    }

    private void FixedUpdate()
    {
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
        if (Input.GetMouseButtonDown(0) && !clickSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("movement", move.magnitude);

    }

    private void OnMouseDown()
    {
        
        clickSelf = true;
        SendMessage("stamDrain", 1);

    }


    private void OnMouseUp()
    {
        clickSelf = false;


    }


    public void stamDrain(float lowStam)
    {
        stamina -= lowStam;
        stamina = Mathf.Clamp(stamina, 0, maxStam);
        if (stamina <= 0)
        {
            noStam = true;
            //animator.SetTrigger("");

        }
        else
        {
            noStam = false;
            animator.SetTrigger("loseStam");
        }
    }

}

