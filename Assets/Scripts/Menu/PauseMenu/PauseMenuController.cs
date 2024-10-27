using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{

    public GameObject pauseMenuObject;

    private bool isGamePaused = false;

    void Start()
    {
        
    }

    
    
    void Update()
    {
        CheckForPause();
    }

    private void CheckForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            PauseUnpause(isGamePaused);
        }
    }

    private void PauseUnpause(bool pause)
    {
        if (pause)
        {
            if(SoundManager.Instance != null)
            {
                SoundManager.Instance.PauseMusic(true);
            }
            pauseMenuObject.SetActive(pause);
            Time.timeScale = 0;
        }else
        {
            Time.timeScale = 1;
            pauseMenuObject.SetActive(pause);
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PauseMusic(false);
            }
        }
    }
}
