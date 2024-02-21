using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.S)) // if s is pressed go to next scene
        {

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //loads the next scene
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;




            SceneManager.LoadScene(nextSceneIndex);

        }

    }
}



