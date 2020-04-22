using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnchorBehaviour : MonoBehaviour
{
    public int order;
    public int gameState;
    public string sceneToGo;
    public string paramSwitchMenu;
    public int type; //0: Bouton de Transition; 1: Bouton Quitter; 2: Bouton de pause; 3: Bouton de switch de canvas
    [HideInInspector]
    public Button button;
    [HideInInspector]
    public GameObject self;

    private void Start()
    {
        button = GetComponent<Button>();
        self = gameObject;

    }

}
