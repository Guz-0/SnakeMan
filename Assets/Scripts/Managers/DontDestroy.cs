using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;

    private void Awake()
    {
        SceneManager.activeSceneChanged += SceneChangedDelegte;

        CheckDuplicates();
    }

    private void SceneChangedDelegte(Scene current, Scene next)
    {
        CheckDuplicates();
    }

    private void CheckDuplicates()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("INSTANCE IS NOT ME");
        }
        else
        {
            Instance = this;
            Debug.Log("I AM THE ONLY INSTANCE");
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= SceneChangedDelegte;
    }

}
