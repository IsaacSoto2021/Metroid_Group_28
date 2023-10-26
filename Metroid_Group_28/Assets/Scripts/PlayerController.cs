using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Remstedt, Reed
// 10/26/2023
// player controller, handles movement
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 1f;

    private Rigidbody rigidbodyRef;
    private Vector3 startPos;
    public int Lives = 99;


    // Start is called before the first frame update
    void Start()
    {
        //get and store the rigidbody
        rigidbodyRef = GetComponent<Rigidbody>();
        //get and store starting position
        startPos = transform.position;

    }//start

    // Update is called once per frame
    void Update()
    {
        //movement controlls 

        //move Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        //move Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //Jump
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

    }//update

    private void Jump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {

            rigidbodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }//jump
}
