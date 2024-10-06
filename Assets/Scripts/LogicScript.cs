using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;

    [ContextMenu("Increase Score")]
    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

}
