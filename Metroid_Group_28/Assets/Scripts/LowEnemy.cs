using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// remstedt,reed
// 10/31/2023
// SideToSide basic Enemy Script movement script

public class SideToSideEnemyScript : MonoBehaviour
{
    public float travelDistanceRight = 0;
    public float travelDistanceLeft = 0;
    public float speed = 1;
    private float startingX;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        // store initial x value at start
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            // only move right if movingRight is true AND x position is not past max distance
            if (transform.position.x <= startingX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            //once max distance right is reached set movingRight to false
            else
            {
                movingRight = false;
            }
        }
        else
        {
            // only move left if movingRight is false AND x position is not past max distance
            if (transform.position.x >= startingX + travelDistanceLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            //once max distance left is reached set movingRight to true
            else
            {
                movingRight = true;
            }
        }
   

    }//update

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
         if (other.gameObject.tag == "HeavyBullet")
        {
            Destroy(gameObject);
        }
    }

}//class
