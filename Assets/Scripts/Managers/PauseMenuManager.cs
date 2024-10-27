using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneFromManager(string scene)
    {
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic();
        ScenesManager.Instance.LoadThisScene(scene);
    }
}
