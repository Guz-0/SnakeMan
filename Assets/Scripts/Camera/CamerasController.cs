using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CamerasController : MonoBehaviour
{

    [Header("Movement info 1")]
    public Vector3 cameraDestination1;
    public float movementDuration1;
    public AnimationCurve movementCurve1;

    [Header("Movement info 2")]
    public Vector3 cameraDestination2;
    public float movementDuration2;
    public AnimationCurve movementCurve2;

    [Header("Scale info")]
    public float finalOrtoSize;
    public float scaleDuration;
    public AnimationCurve scaleCurve;


    public float secondsBetweenMovements;

    public GameObject HUD;

    private PlayerController player;

    void Start()
    {
        HUD.SetActive(false);
        StartCoroutine(MovingCamera());
        player = GameObject.FindWithTag("PLAYER").GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    IEnumerator MovingCamera()
    {
        cameraDestination1 = new Vector3(cameraDestination1.x, cameraDestination1.y, transform.position.z);
        transform.DOMove(cameraDestination1, movementDuration1).SetEase(movementCurve1);

        yield return new WaitForSeconds(movementDuration1 + secondsBetweenMovements);

        
        cameraDestination2 = new Vector3(cameraDestination2.x, cameraDestination2.y, transform.position.z);
        transform.DOMove(cameraDestination2, movementDuration2).SetEase(movementCurve2);

        yield return new WaitForSeconds(movementDuration2);

        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayMusic();
            GameManager.Instance.UnsetIsFirstTimeLoading();
        }

        yield return new WaitForSeconds(secondsBetweenMovements);

        Camera.main.DOOrthoSize(finalOrtoSize, scaleDuration).SetEase(scaleCurve);

        yield return new WaitForSeconds(scaleDuration);


        HUD.SetActive(true);
        player.SetAbleToMoveTrue();

        yield return null;


    }
}
