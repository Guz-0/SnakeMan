using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static Action OnPlayerMovement;

    public static Action OnScoreChange;

    public static Action OnPlayerDeath;

    private bool up;
    private bool down;
    private bool right;
    private bool left;

    private const int UP = 1;
    private const int DOWN = 2;
    private const int RIGHT = 3;
    private const int LEFT = 4;

    private int whereToMove = 0;
    private int lastWhereToMove = 0;

    public float countdown;
    private float timeElapsed;

    public Vector3 myLastPosition;
    private Vector3 myCurrentPosition;

    private List<GameObject> attachmentList;
    public GameObject attachmentObj;

    public int horizontalBound;
    public int verticalBound;

    private int matchScore = 0;

    private bool ableToMove = false;

    void Start()
    {
        attachmentList = new List<GameObject>();

        myCurrentPosition = transform.position;
        myLastPosition = myCurrentPosition;

        attachmentList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Movement();
        PacManEffect();
    }

    void PacManEffect()
    {
        if(Mathf.Abs(transform.position.x) == horizontalBound && Mathf.Abs(transform.position.x) <= horizontalBound)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        if (Mathf.Abs(transform.position.y) == verticalBound && Mathf.Abs(transform.position.y) <= verticalBound)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        }
    }

    void Movement()
    {
        if (ableToMove)
        {
            if (Input.GetKey(KeyCode.UpArrow) && lastWhereToMove != DOWN && !(Mathf.Abs(transform.position.x) == horizontalBound))
            {
                whereToMove = UP;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && lastWhereToMove != UP && !(Mathf.Abs(transform.position.x) == horizontalBound))
            {
                whereToMove = DOWN;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && lastWhereToMove != LEFT && !(Mathf.Abs(transform.position.y) == verticalBound))
            {
                whereToMove = RIGHT;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && lastWhereToMove != RIGHT && !(Mathf.Abs(transform.position.y) == verticalBound))
            {
                whereToMove = LEFT;
            }

            if (timeElapsed >= countdown && whereToMove != 0)
            {

                for (int i = attachmentList.Count - 1; i > 0; i--)
                {
                    attachmentList[i].transform.position = attachmentList[i - 1].transform.position;
                }

                switch (whereToMove)
                {
                    case UP:
                        transform.position = transform.position + new Vector3(0f, transform.localScale.x, 0f);
                        break;
                    case DOWN:
                        transform.position = transform.position + new Vector3(0f, -transform.localScale.x, 0f);
                        break;
                    case RIGHT:
                        transform.position = transform.position + new Vector3(transform.localScale.x, 0f, 0f);
                        break;
                    case LEFT:
                        transform.position = transform.position + new Vector3(-transform.localScale.x, 0f, 0f);
                        break;
                }

                lastWhereToMove = whereToMove;


                /*
                myLastPosition = myCurrentPosition;

                myCurrentPosition = transform.position;

                OnPlayerMovement.Invoke();
                */
            }

            if (timeElapsed >= countdown)
            {
                timeElapsed = 0f;
            }

            timeElapsed = +timeElapsed + Time.deltaTime;
        }
    }

    private void Grow()
    {

        Vector3 attachmentPosition = attachmentList[attachmentList.Count - 1].transform.position;
        GameObject attachment = Instantiate(attachmentObj, attachmentPosition, transform.rotation);
        attachmentList.Add(attachment);

        matchScore += 10;
        if(GameManager.Instance != null)
        {
            GameManager.Instance.SetMatchScore(matchScore);
        }
        OnScoreChange.Invoke();
    }

    private void PlayerDeath()
    {
        OnPlayerDeath.Invoke();
    }

    public void SetAbleToMoveTrue()
    {
        ableToMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FOOD"))
        {
            Grow();
        }
        else
        {
            if (collision.CompareTag("ATTACHMENT"))
            {
                if(attachmentList.Count-1 > 1)
                {
                    PlayerDeath();
                }
            }
        }
    }
}
