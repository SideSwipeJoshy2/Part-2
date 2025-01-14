using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class knight : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 move;
    public float speed = 3;
    Animator animator;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead = false;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
        health = PlayerPrefs.GetFloat("hp");
    }

    private void FixedUpdate()
    {
        if(isDead) return;
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
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("movement", move.magnitude);

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("attack");
        }

    }

    private void OnMouseDown()
    {
        if(isDead) return;
        clickingOnSelf = true;
        SendMessage("TakeDamage", 1);
        ///TakeDamage(1);
        
    }


    private void OnMouseUp()
    {
        clickingOnSelf = false;

        
    }

   public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");

        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}

