using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public Slider slider;
    public void drainStam(float stam)
    {
        slider.value -= stam;
    }
}
