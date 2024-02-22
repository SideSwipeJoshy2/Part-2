using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public Color selectedColour;
    public Color unselectedColour;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float speed = 100;
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Selected(false);
    }
    private void OnMouseDown()
    {

        controller.SetCurrentSelection(this);
    }
    public void Selected(bool isSelected)
    {

        if (isSelected)
        {
            sr.color = selectedColour;

        }
        else
        {
            sr.color = unselectedColour;
        }
    }
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}