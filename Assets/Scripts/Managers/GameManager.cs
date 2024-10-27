using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private bool isPlayerAlive;

    private bool isFirstTimeLoading = true;

    private int matchScore;
    private int highScore;

    void Start()
    {
        isPlayerAlive = true;
        matchScore = highScore = 0;
    }

    void Update()
    {
        
    }

    public void SetPlayerLifeStatus(bool status)
    {
        isPlayerAlive = status;
    }

    public bool GetPlayerLifeStatus()
    {
        return isPlayerAlive;
    }

    public void SetMatchScore(int value)
    {
        matchScore = value;
    }

    public int GetMatchScore()
    {
        return matchScore;
    }

    public void SetHighScore(int value)
    {
        highScore = value;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public bool GetIsFirstTimeLoading()
    {
        return isFirstTimeLoading;
    }

    public void UnsetIsFirstTimeLoading()
    {
        isFirstTimeLoading = false;
    }
}
