using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static int score = 0;
    private Text text;

    private void Start()
    {
        score = 0;
        text = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        text.text = score + " / " + LevelController.GscoreToWin;
    }
}
