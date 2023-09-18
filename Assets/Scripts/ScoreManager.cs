using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ResetOnHit[] _restartOnHit;

    public TextMeshProUGUI[] scoreText;

    public int playerLeftscore, playerRightscore;
    
    private void Awake()
    {
        scoreText = FindObjectsOfType<TextMeshProUGUI>();
        _restartOnHit = FindObjectsOfType<ResetOnHit>();
    }

    private void Start()
    {
        _restartOnHit[0].AddScoreRight += AddPointRight;
        _restartOnHit[1].AddScoreLeft += AddPointLeft;
        
        scoreText[0].text = "0" + playerLeftscore.ToString();
        scoreText[1].text = "0" + playerLeftscore.ToString();
    }

    private void AddPointLeft(int i)
    {
        Debug.Log("Left Point Added");
        playerLeftscore += i;
        if (playerLeftscore < 10)
        {
            scoreText[0].text = "0" + playerLeftscore.ToString();
        }
        else
        {
            scoreText[0].text = playerLeftscore.ToString();
        }
    }
    
    private void AddPointRight(int i)
    {
        Debug.Log("Right Point Added");

        playerRightscore += i;
        if (playerRightscore < 10)
        {
            scoreText[1].text = "0" + playerRightscore.ToString();
        }
        else
        {
            scoreText[1].text = playerRightscore.ToString();
        }
    }
}