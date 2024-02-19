using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 move;
    Vector2 destination;
    bool clickSelf =false;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clickSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
     //   animator.SetFloat("movement", move.magnitude);

    }

    private void OnMouseUp()
    {
        clickSelf = false;


    }
    
}

