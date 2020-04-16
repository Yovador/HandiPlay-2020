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
                    Debug.Log("Input for pause = " + InputManager.Gpause + " KeyPressed : " + InputManager.KeyPressed);
                    InputManager.Gpause = InputManager.KeyPressed;
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
