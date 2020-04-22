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
        AudioManager.soundToPlay.Clear();
        GameManager.gameState = gameState;
    }

    public void SoundOnClick()
    {
        AudioManager.PlayASound("MenuClick");
    }

    public void UnPause()
    {
        GameManager.gamePauseOn = false;
    }

    public void CloseGame()
    {
        Application.Quit();

    }
}

public class Menu
{

    private GameObject genMenu;
    private GameObject audioMenu;
    private GameObject graphMenu;



    public void SwitchScene(string scenename)
    {
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
    }

    public void SwitchgameState(int gameState)
    {
        AudioManager.soundToPlay.Clear();
        GameManager.gameState = gameState;
    }

    public void SoundOnClick()
    {
        AudioManager.PlayASound("MenuClick");
    }

    public void UnPause()
    {
        GameManager.gamePauseOn = false;
    }

    public void CloseGame()
    {
        Application.Quit();

    }

    private void InitSwitchMenu()
    {

        genMenu = GameObject.Find("genMenu");

        audioMenu = GameObject.Find("audioMenu");

        graphMenu = GameObject.Find("graphMenu");
    }
}
