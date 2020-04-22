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
                Change(InputManager.Gpause, "pause");
                break;

            case "Up":
                Change(InputManager.Gup, "up");
                break;

            case "Down":
                Change(InputManager.Gdown, "down");
                break;

            case "Right":
                Change(InputManager.Gright, "right");

                break;

            case "Left":
                Change(InputManager.Gleft, "left");
                break;

            case "Mouseless":
                Change(InputManager.GmouseLessNavigation, "mouseless");
                break;

            case "Confirm":
                Change(InputManager.Gconfirm, "confirm");
                break;

            default:
                break;
        }


    }

    private void Change(KeyCode inputToBind, string playerPrefkey)
    {
        if (waitingForInput && InputManager.KeyPressed != KeyCode.Mouse0)
        {
            text.text = inputToBind.ToString();
            InputManager.Gpause = InputManager.KeyPressed;
            PlayerPrefs.SetString(playerPrefkey, inputToBind.ToString());
            waitingForInput = false;
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
