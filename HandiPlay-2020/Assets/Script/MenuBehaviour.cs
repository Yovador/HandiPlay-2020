﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuBehaviour : MonoBehaviour
{
    //Change the Scene, scenename is set in the inspector
    public void SwitchScene(string scenename)
    {
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
    }

    public void SwitchgameState(int gameState)
    {
        GameManager.gameState = gameState;
    }

    public void UnPause()
    {
        GameManager.gamePauseOn = false;
    }
}
