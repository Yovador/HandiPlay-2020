using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextColorChange : MonoBehaviour
{
    private Text text;
    public Color baseColor;
    public Color selectedColor;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        selectedColor.a = 1;
        baseColor.a = 1;
    }
    private void Update()
    {
        if (gameObject == MouselessNavigation.selectedObject)
        {
            text.color = selectedColor;
        }
        else
        {
            text.color = baseColor; 
        }
    }

}
