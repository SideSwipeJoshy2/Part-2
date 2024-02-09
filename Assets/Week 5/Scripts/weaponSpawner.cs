using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class weaponSpawner : MonoBehaviour
{

    public GameObject AxeSpawner;
   
    public void spawer()
    {
        Instantiate(AxeSpawner, Vector3.zero, quaternion.identity);

    }

}