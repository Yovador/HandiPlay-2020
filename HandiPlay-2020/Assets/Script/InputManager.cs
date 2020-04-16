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


    public static KeyCode Gup;
    public static KeyCode Gdown;
    public static KeyCode Gright;
    public static KeyCode Gleft;
    public static KeyCode Gpause;


    private void Start()
    {
        Gup = up;
        Gdown = down;
        Gright = right;
        Gleft = left;
        Gpause = pause;

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
