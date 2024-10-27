using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuController : MonoBehaviour
{

    public GameObject deathMenuObj;
    
    void Start()
    {
        PlayerController.OnPlayerDeath += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDeath()
    {
        deathMenuObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        if(ScenesManager.Instance != null)
        {
            ScenesManager.Instance.LoadThisScene("Game");
        }
    }

    public void LoadMenu()
    {
        if (ScenesManager.Instance != null)
        {
            ScenesManager.Instance.LoadThisScene("Menu");
        }
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= OnDeath;
    }
}
