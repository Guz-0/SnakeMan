using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{

    public int verticalMin;

    public int horizontalMin;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void RandomPosition()
    {
        int y = Random.Range(verticalMin, -verticalMin);
        int x = Random.Range(horizontalMin, -horizontalMin);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") || collision.CompareTag("ATTACHMENT"))
        {
            Debug.Log("ECOUNTERED-> " + collision.name);
            RandomPosition();
        }
    }
}
