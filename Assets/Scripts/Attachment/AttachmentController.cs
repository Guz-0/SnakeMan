using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttachmentController : MonoBehaviour
{
    public GameObject lastAttachment;
    private Vector3 lastAttchmentLastPosition;
    private Vector3 lastAttachmentActualPosition;
    private Vector3 playerPosition;
    private Vector3 oldPlayerPosition;

    public Vector3 myLastPosition;
    private Vector3 myActualPosition;

    private Vector3 positionToGoTo;


    void Start()
    {

        myActualPosition = transform.position;
        myLastPosition = myActualPosition;

        PlayerController.OnPlayerMovement += Move;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        
        
    }

    private void Move()
    {
        myActualPosition = transform.position;
        CheckLastAttachmentInfo();
        lastAttachmentActualPosition = lastAttachment.transform.position;



        myLastPosition = myActualPosition;


        if (!lastAttachment.CompareTag("PLAYER"))
        {

        }

        Debug.Log(gameObject.name + " " + positionToGoTo);
        transform.position = positionToGoTo;

    }

    private void CheckLastAttachmentInfo()
    {
        if (lastAttachment.CompareTag("PLAYER"))
        {
            lastAttchmentLastPosition = lastAttachment.GetComponent<PlayerController>().myLastPosition;
            positionToGoTo = lastAttachment.GetComponent<PlayerController>().myLastPosition;
        }
        else
        {
            lastAttchmentLastPosition = lastAttachment.GetComponent<AttachmentController>().myLastPosition;
            positionToGoTo = lastAttachment.GetComponent<AttachmentController>().myLastPosition;
        }
    }

    IEnumerator waitUntilObjMoves()
    {
        yield return new WaitUntil(() => lastAttchmentLastPosition != lastAttachmentActualPosition);
    }

    private void OnDestroy()
    {
        PlayerController.OnPlayerMovement -= Move;
    }
}
