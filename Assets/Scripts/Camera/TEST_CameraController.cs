using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TEST_CameraController : MonoBehaviour
{

    public Vector2 cameraDestinaton;
    private float forward;

    private Vector3 startingPosition;
    public Vector3 finishingPosition;

    public float duration;
    private float startingDuration;
    private float slowedDuration;
    private float startTime;

    public AnimationCurve curve;

    void Start()
    {
        if (gameObject.CompareTag("CAMERA_MENU"))
        {

        }
        else if (gameObject.CompareTag("CAMERA_GAME"))
        {

        }
        MainMenuManager.onGameStart += OnGameStart;

        startingPosition = transform.position;
        startTime = Time.time;
        startingDuration = duration;
    }


    void FixedUpdate()
    {
        OnGameStart();
    }

    private void OnGameStart()
    {
        forward = (Time.time - startTime) / duration;
        Debug.Log(forward);
        transform.position = new Vector3(Mathf.SmoothStep(startingPosition.x, finishingPosition.x, curve.Evaluate(forward)), transform.position.y, transform.position.z);



        if (transform.position.x == finishingPosition.x)
        {
            Vector3 dummy = finishingPosition;
            finishingPosition = startingPosition;
            startingPosition = dummy;
            forward = 0;
            startTime = Time.time;
            duration = startingDuration;
        }/*else if (forward > 0.6f)
        {
            duration += 0.005f;
        }*/


    }

}
