using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Button : MonoBehaviour//was the name of the old use for this script, figured that it would still work for the orb though
{
    public GameObject prefab;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("stamDrain", 1, SendMessageOptions.DontRequireReceiver);///uses send message to allow the player to take damage from the orb
    }

    
}
