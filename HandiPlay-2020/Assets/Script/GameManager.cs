using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public float timeBetweenFrame;
    public static int gameState; //0 = menu; 1 = in game;
    public static bool gamePauseOn = false;
    private bool gameInit = false;
    private GameObject pauseMenu;
    private GameObject gameUI;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("GameSpeed"))
        {
            PlayerPrefs.SetFloat("GameSpeed", timeBetweenFrame);
        }
    }

    private void Update()
    {
        if (gameState == 1)
        {
            if (!gameInit)
            {
                pauseMenu = GameObject.Find("PauseMenu");
                pauseMenu.SetActive(false);
                gameUI = GameObject.Find("GameUI");
                gameUI.SetActive(true);
                gameInit = true;
            }

            if (Input.GetKeyDown(InputManager.Gpause))
            {
                gamePauseOn = !gamePauseOn;
            }

            if (gamePauseOn)
            {
                pauseMenu.SetActive(true);
                gameUI.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(false);
                gameUI.SetActive(true);
            }
        }
        if (gameState == 0)
        {
            gameInit = false;
            gamePauseOn = false;
        }

    }
}
