using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    private void Update()
{
    scoreText.text = "Score: " + ScoreManager.playerScore.ToString();
}
}

