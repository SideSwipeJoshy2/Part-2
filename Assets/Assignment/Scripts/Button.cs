using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Button : MonoBehaviour
{
    public GameObject prefab;
    float position;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("stamDrain", 1, SendMessageOptions.DontRequireReceiver);
    }

    
}
