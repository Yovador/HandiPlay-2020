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
        if (PlayerPrefs.HasKey("down"))
        {
            Gdown = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("down"));
        }
        if (PlayerPrefs.HasKey("right"))
        {
            Gright = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("right"));
        }
        if (PlayerPrefs.HasKey("left"))
        {
            Gleft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("left"));
        }
        if (PlayerPrefs.HasKey("pause"))
        {
            Gpause = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pause"));
        }
        if (PlayerPrefs.HasKey("mouseless"))
        {
            GmouseLessNavigation = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("mouseless"));
        }
        if (PlayerPrefs.HasKey("confirm"))
        {
            Gconfirm = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("confirm"));
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

