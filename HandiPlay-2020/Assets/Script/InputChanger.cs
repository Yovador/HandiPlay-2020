using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputChanger : MonoBehaviour
{
    public string inputName;
    private Text text;
    private bool waitingForInput = false;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = inputName;
    }

    private void Update()
    {
        switch (inputName)
        {
            case "Pause":
                text.text = InputManager.Gpause.ToString();
                if (waitingForInput && InputManager.KeyPressed != KeyCode.Mouse0)
                {
                    InputManager.Gpause = InputManager.KeyPressed;
                    PlayerPrefs.SetString("pause", InputManager.Gpause.ToString());
                    waitingForInput = false;
                }
                break;
            case "Up":
                text.text = InputManager.Gup.ToString();
                if (waitingForInput && InputManager.KeyPressed != KeyCode.Mouse0)
                {
                    InputManager.Gup = InputManager.KeyPressed;
                    PlayerPrefs.SetString("up", InputManager.Gup.ToString());
                    waitingForInput = false;
                }
                break;
            case "Down":
                text.text = InputManager.Gdown.ToString();
                if (waitingForInput && InputManager.KeyPressed != KeyCode.Mouse0)
                {
                    InputManager.Gdown = InputManager.KeyPressed;
                    PlayerPrefs.SetString("down", InputManager.Gdown.ToString());
                    waitingForInput = false;
                }
                break;
            case "Right":
                text.text = InputManager.Gright.ToString();
                if (waitingForInput && InputManager.KeyPressed != KeyCode.Mouse0)
                {
                    InputManager.Gright = InputManager.KeyPressed;
                    PlayerPrefs.SetString("right", InputManager.Gright.ToString());
                    waitingForInput = false;
                }
                break;
            case "Left":
                text.text = InputManager.Gleft.ToString();
                if (waitingForInput && InputManager.KeyPressed != KeyCode.Mouse0)
                {
                    InputManager.Gleft = InputManager.KeyPressed;
                    PlayerPrefs.SetString("left", InputManager.Gleft.ToString());
                    waitingForInput = false;
                }
                break;
            default:
                break;
        }


    }


    public void ButtonChange()
    {
        if (!waitingForInput)
        {
            waitingForInput = !waitingForInput;
        }
    }
}
