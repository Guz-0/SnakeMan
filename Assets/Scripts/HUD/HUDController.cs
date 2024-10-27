using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public TMP_Text matchScoreText;
    public TMP_Text highScoreText;

    private int matchScoreValue;
    private int highScoreValue;

    private const string MATCH_SCORE = "SCORE:\n";
    private const string HIGH_SCORE = "HIGHSCORE:\n";

    void Start()
    {
        PlayerController.OnScoreChange += UpdateMatchScore;

        if(GameManager.Instance != null)
        {
            highScoreValue = GameManager.Instance.GetHighScore();
        }
        highScoreText.SetText(HIGH_SCORE + highScoreValue);
    }

    void Update()
    {
        
    }

    void UpdateMatchScore()
    {
        if(GameManager.Instance != null)
        {
            matchScoreValue = GameManager.Instance.GetMatchScore();
        }

        matchScoreText.SetText(MATCH_SCORE + matchScoreValue);
    }

    private void OnDestroy()
    {
        PlayerController.OnScoreChange -= UpdateMatchScore;


        if(matchScoreValue > highScoreValue)
        {
            highScoreValue = matchScoreValue;
            if(GameManager.Instance != null)
            {
                GameManager.Instance.SetHighScore(matchScoreValue);
            }
        }
    }
}
