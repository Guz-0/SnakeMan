using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [Header("Buttons")]
    public List<GameObject> buttonsList;

    [Header("Time between buttons")]
    public float buttonsAppearingAfter;

    public static Action onGameStart;

    [Header("Menu movement")]
    public GameObject menuObject;
    public Vector2 menuFinalDestination;
    public float movementDuration;
    public AnimationCurve movementCurve;
    private RectTransform menuRect;

    private AsyncOperation asyncLoad;

    void Start()
    {
        menuRect = menuObject.GetComponent<RectTransform>();

        for(int i = 0; i < buttonsList.Count; i++)
        {
            buttonsList[i].GetComponent<Button>().enabled = false;
            buttonsList[i].SetActive(false);
        }
        StartCoroutine(ButtonsAnimaton());
        Debug.Log("START");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ButtonsAnimaton()
    {
        for(int i=0; i<buttonsList.Count; i++)
        {
            yield return new WaitForSeconds(buttonsAppearingAfter);
            buttonsList[i].SetActive(true);
            Debug.Log(i);

        }
        for (int i =0; i<buttonsList.Count; i++)
        {
            buttonsList[i].GetComponent<Button>().enabled = true;
        }
        /*if (GameManager.Instance.GetIsFirstTimeLoading())
        {
            SoundManager.Instance.PlayMusic();
            GameManager.Instance.UnsetIsFirstTimeLoading();
        }*/
        yield return null;
    }

    public void MoveMenuToStartGame(string scene)
    {
        
        asyncLoad = SceneManager.LoadSceneAsync(scene);
        asyncLoad.allowSceneActivation = false;
        //Vector3 finalDestinationV3 = new Vector3(menuFinalDestination.x, menuFinalDestination.y, transform.position.z);

        DisableAllButtons();

        menuRect.DOAnchorPos(menuFinalDestination, movementDuration, true).SetEase(movementCurve).OnComplete(() =>
        {
            StartCoroutine(WaitUntilSceneLoads(asyncLoad));
            
        });
    }

    private void DisableAllButtons()
    {
        for(int i = 0; i < buttonsList.Count; i++)
        {
            buttonsList[i].GetComponent<Button>().enabled = false;
        }
    }

    IEnumerator WaitUntilSceneLoads(AsyncOperation asyncLoad)
    {
        do
        {
            Debug.Log(asyncLoad.progress);
        } while (asyncLoad.progress < 0.9f);
        asyncLoad.allowSceneActivation = true;
        yield return null;
    }


}
