using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public List<GameObject> listOfObjectsToMove;
    private UpDown upDownScript;

    public float timer;
    private bool timerActive;

    public GameObject player;
    private InGameUI inGameUI;

    public GameObject levelManager;

    public void StartGame()
    {
        foreach (GameObject x in listOfObjectsToMove) {
            upDownScript = x.GetComponent<UpDown>();
            upDownScript.Move();
        }

        timerActive = true;
    }

    public void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
        }


        if (timer >= 3)
        {
            SpawnPlayer();
            inGameUI = levelManager.GetComponent<InGameUI>();
            inGameUI.gameInSession = true;
        }
    }
    public void ExitGame()
    {
        Debug.Log("Application.Quit()");
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("StartingScene");
    }

    public void SpawnPlayer()
    {
        timerActive = false;
        timer = 0;
        Instantiate(player, new Vector2(0, 0), Quaternion.identity);
    }
}
