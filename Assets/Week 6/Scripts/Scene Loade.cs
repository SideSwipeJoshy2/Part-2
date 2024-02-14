using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoade : MonoBehaviour
{
  public void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;



        
            SceneManager.LoadScene(nextSceneIndex);

        }
        
    }
}
