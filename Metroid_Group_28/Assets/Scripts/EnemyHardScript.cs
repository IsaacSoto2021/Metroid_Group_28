using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Remstedt,Reed
// 11/9/2023
//  hard Enemy Script, movement script plus logic

public class EnemyHardScript: MonoBehaviour
{
    public float travelDistanceRight = 0;
    public float travelDistanceLeft = 0;
    public float speed = 1;
    private float startingX;
    private bool movingRight = true;
    private int health = 10;
 
    public GameObject playerModel;
    public Vector3 playerPos;
  
  


    // Start is called before the first frame update
    void Start()
    {
        // store initial x value at start
        startingX = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerModel.transform.position;

        if (transform.position.x <= playerPos.x)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }


      if (movingRight)
        {
            // only move right if movingRight is true AND x position is not past max distance
            if (transform.position.x <= startingX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
          
           
        }
        else
        {
            // only move left if movingRight is false AND x position is not past max distance
            if (transform.position.x >= startingX + travelDistanceLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            
           
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }//update

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health += -1;
        }
         if (other.gameObject.tag == "HeavyBullet")
        {
            health += -3;
        }
    }

}//class
