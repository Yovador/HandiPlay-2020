using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouselessNavigation : MonoBehaviour
{
    private Menu menu;
    private List<GameObject> navigationAnchor;
    private List<int> order = new List<int>();
    private int anchorNumber = 0;
    private AnchorBehaviour infoAnchor;
    private List<AnchorBehaviour> listofAnchor = new List<AnchorBehaviour>();
    public static GameObject selectedObject;

    private void Start()
    {
        menu = new Menu() ;
        GetAnchorOrder();
    }

    private void Update()
    {
        GetAnchorOrder();
        if (navigationAnchor.Count > 0)
        {
            GetAnchorInfo();
            if (Input.GetKeyDown(InputManager.GmouseLessNavigation))
            {
                if (anchorNumber == navigationAnchor.Count - 1)
                {
                    anchorNumber = 0;
                }
                else
                {
                    anchorNumber++;

                }

            }
            selectedObject = infoAnchor.self;
            transform.position = infoAnchor.transform.position;
            infoAnchor.button.Select();

            if (Input.GetKeyDown(InputManager.Gconfirm))
            {
                switch (infoAnchor.type)
                {
                    case 0:
                        menu.SwitchgameState(infoAnchor.gameState);
                        menu.SoundOnClick();
                        menu.SwitchScene(infoAnchor.sceneToGo);
                        Init();
                        break;
                    case 1:
                        menu.SoundOnClick();
                        menu.CloseGame();
                        break;
                    case 2:
                        menu.SoundOnClick();
                        menu.UnPause();
                        Init();
                        break;
                    case 3:
                        ParamMenu.switchTo = infoAnchor.paramSwitchMenu;
                        Init();
                        break;
                    default:
                        break;
                }
            }
        }
        
    }

    private void Init()
    {
        navigationAnchor = new List<GameObject>();
        infoAnchor = null;
        anchorNumber = 0;
        order = new List<int>();
        listofAnchor = new List<AnchorBehaviour>();
        ParamMenu.switchTo = null;

    }

    private void GetAnchorInfo()
    {
        foreach (var anchor in listofAnchor)
        {
            if (anchor.order == anchorNumber)
            {
                infoAnchor = anchor;
            }
        }
        
    }

    private void GetAnchorOrder()
    {
        navigationAnchor = new List<GameObject>(GameObject.FindGameObjectsWithTag("Anchor"));
        if (GameObject.FindGameObjectsWithTag("Anchor").Length > 0)
        {
            Debug.Log("Found Anchor");
        }
        foreach (var anchor in navigationAnchor)
        {
            AnchorBehaviour behaviour = anchor.GetComponent<AnchorBehaviour>();
            listofAnchor.Add(behaviour);
            if (behaviour != null)
            {
                Debug.Log("behaviour found" + behaviour.order +behaviour.sceneToGo);
            }
            order.Add(behaviour.order);
        }
        order.Sort();


    }
}
