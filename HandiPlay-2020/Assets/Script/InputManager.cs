using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static KeyCode KeyPressed;

 
    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public KeyCode pause;
    public KeyCode mouseLessNavigation;
    public KeyCode confirm;


    public static KeyCode Gup;
    public static KeyCode Gdown;
    public static KeyCode Gright;
    public static KeyCode Gleft;
    public static KeyCode Gpause;
    public static KeyCode GmouseLessNavigation;
    public static KeyCode Gconfirm;

    private void Start()
    {
        Gup = up;
        Gdown = down;
        Gright = right;
        Gleft = left;
        Gpause = pause;
        GmouseLessNavigation = mouseLessNavigation;
        Gconfirm = confirm;

        if (PlayerPrefs.HasKey("up"))
        {
            Gup = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("up"));
        }
        else
        {
            PlayerPrefs.SetString("up", GmouseLessNavigation.ToString());
        }
        if (PlayerPrefs.HasKey("down"))
        {
            Gdown = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("down"));
        }
        else
        {
            PlayerPrefs.SetString("down", GmouseLessNavigation.ToString());
        }
        if (PlayerPrefs.HasKey("right"))
        {
            Gright = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("right"));
        }
        else
        {
            PlayerPrefs.SetString("right", GmouseLessNavigation.ToString());
        }
        if (PlayerPrefs.HasKey("left"))
        {
            Gleft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("left"));
        }
        else
        {
            PlayerPrefs.SetString("left", GmouseLessNavigation.ToString());
        }
        if (PlayerPrefs.HasKey("pause"))
        {
            Gpause = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pause"));
        }
        else
        {
            PlayerPrefs.SetString("pause", GmouseLessNavigation.ToString());
        }
        if (PlayerPrefs.HasKey("mouseless"))
        {
            GmouseLessNavigation = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("mouseless"));
        }
        else
        {
            PlayerPrefs.SetString("mouseless", GmouseLessNavigation.ToString());
        }
        if (PlayerPrefs.HasKey("confirm"))
        {
            Gconfirm = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("confirm"));
        }
        else
        {
            PlayerPrefs.SetString("confirm", GmouseLessNavigation.ToString());
        }

    }

private void Update()
    {
        foreach (KeyCode PressedKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(PressedKey))
            {
                KeyPressed = PressedKey;
            }
        }
    }

}

