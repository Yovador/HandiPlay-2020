using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpControl : MonoBehaviour
{

    private GameObject popUp;
    public static Text nameInput;
    private Text newInput;
    public static Text prevInput;
    public static string controlChange;
    private KeyCode lastKey;


    private void Start()
    {
        popUp = transform.Find("PopUp").gameObject;
        nameInput = popUp.transform.Find("NameInput").transform.Find("NameInput").GetComponent<Text>();
        newInput = popUp.transform.Find("NewInput").transform.Find("NewInput").GetComponent<Text>();
        prevInput = popUp.transform.Find("PrevInput").transform.Find("PrevInput").GetComponent<Text>();
        Debug.Log("nameInput : " + nameInput.text + "nextInput : " + newInput.text + "prevInput : " + prevInput.text);

    }

    private void Update()
    {
        popUp.SetActive(InputChanger.waitingForInput);

        if (InputManager.KeyPressed != KeyCode.Mouse0)
        {
            Debug.Log("Key Different From Mouse0 ");
            lastKey = InputManager.KeyPressed;
        }
        Debug.Log("Last key : " + lastKey);
        if (InputChanger.waitingForInput)
        {
            newInput.text = lastKey.ToString();
        }


    }

    public void Confirm()
    {
        InputManager.Gpause = lastKey;
        PlayerPrefs.SetString(controlChange, lastKey.ToString());
        InputChanger.waitingForInput = false;
    }

    public void Return()
    {
        InputChanger.waitingForInput = false;
    }
}
