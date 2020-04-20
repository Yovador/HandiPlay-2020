using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamMenu : MonoBehaviour
{
    private GameObject genMenu;
    private GameObject audioMenu;
    private GameObject graphMenu;

    private void Start()
    {
        genMenu = GameObject.Find("genMenu");
        genMenu.SetActive(true);
        audioMenu = GameObject.Find("audioMenu");
        audioMenu.SetActive(false);
        graphMenu = GameObject.Find("graphMenu");
        graphMenu.SetActive(false);
    }

    public void SwitchMenu(string menu)
    {
        if (menu == "genMenu")
        {
            genMenu.SetActive(true);
            audioMenu.SetActive(false);
            graphMenu.SetActive(false);
        }
        if (menu == "audioMenu")
        {
            genMenu.SetActive(false);
            audioMenu.SetActive(true);
            graphMenu.SetActive(false);
        }
        if (menu == "graphMenu")
        {
            genMenu.SetActive(false);
            audioMenu.SetActive(false);
            graphMenu.SetActive(true);
        }
    }
}
