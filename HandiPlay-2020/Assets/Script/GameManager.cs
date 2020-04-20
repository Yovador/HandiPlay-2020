using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public float timeBetweenFrame;
    public static int gameState = 0; //0 = menu; 1 = in game; 2 = credit
    public static bool gamePauseOn = false;
    private bool gameInit = false;
    private GameObject pauseMenu;
    private GameObject deathMenu;
    private GameObject gameUI;
    private bool playDeathSound = false;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("GameSpeed"))
        {
            PlayerPrefs.SetFloat("GameSpeed", timeBetweenFrame);
        }
    }

    private void Update()
    {
        Debug.Log("GameState : " + gameState);
        if (gameState == 1)
        {
            GameInit();
            Pause();
            Death();

        }
        if (gameState == 0)
        {
            gameInit = false;
            gamePauseOn = false;
        }

    }

    private void GameInit()
    {
        if (!gameInit && PlayerController.isSnakeAlive)
        {
            pauseMenu = GameObject.Find("PauseMenu");
            pauseMenu.SetActive(false);
            deathMenu = GameObject.Find("DeathMenu");
            deathMenu.SetActive(false);
            gameUI = GameObject.Find("GameUI");
            gameUI.SetActive(true);
            gameInit = true;
            playDeathSound = false;
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(InputManager.Gpause))
        {
            gamePauseOn = !gamePauseOn;
        }

        if (gamePauseOn)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }

    private void Death()
    {
        if (!PlayerController.isSnakeAlive)
        {
            if (!playDeathSound)
            {
                AudioManager.PlayASound("DeathSound");
                playDeathSound = true;
            }
            gameInit = false;
            pauseMenu.SetActive(false);
            deathMenu.SetActive(true);
        }
    }
}

