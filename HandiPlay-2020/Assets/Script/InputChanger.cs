using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputChanger : MonoBehaviour
{
    public string inputName;
    private Text desc;
    private Text input;
    public static bool waitingForInput = false;

    private void Start()
    {
        input = transform.Find("InputName").transform.Find("InputName").GetComponent<Text>();
        desc = transform.Find("Description").transform.Find("Description").GetComponent<Text>();
        input.text = inputName;
        Debug.Log("input Text" + input.text + "desc text" + desc.text);
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetString(inputName));
        input.text = PlayerPrefs.GetString(inputName);
    }



    public void ButtonChange()
    {
        waitingForInput = true;
        PopUpControl.nameInput.text = desc.text;
        PopUpControl.prevInput.text = input.text;
        PopUpControl.controlChange = inputName;
    }
}
