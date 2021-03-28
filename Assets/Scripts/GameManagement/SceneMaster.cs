using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneMaster : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneIEnumerator(scene));
    }

    private IEnumerator LoadSceneIEnumerator(string scene)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        asyncOperation.allowSceneActivation = false;
        //Debug.Log("Progress: " + asyncOperation.progress);
        /* while (!asyncOperation.isDone)
         {
             //text.text = "Progress: " + (asyncOperation.progress * 10) + "%";
             if (asyncOperation.progress >= 0.9f)
             {
                 //if (Input.GetKeyDown(KeyCode.Space))
                 //Activate the Scene
                 asyncOperation.allowSceneActivation = true;
             }
             yield return null;
         } */
        asyncOperation.allowSceneActivation = true;
        print("Scene Loaded");
    }
}