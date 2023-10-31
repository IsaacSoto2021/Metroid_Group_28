using System.Collections;
using UnityEngine;


// Remstedt, Reed
// 10/26/2023
// player controller, handles movement, health, and Shooting
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 1f;

    private Rigidbody rigidbodyRef;
    public Vector3 startPos;
    public int Lives = 99;

    public GameObject lightBullet;
    public GameObject heavyBullet;

    private bool isShooting = false;
    private bool isHurt = false;


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


        //Shooting Controlls
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isShooting == false)
            {
                isShooting = true;
                StartCoroutine(WaitToFire());
                Instantiate(lightBullet, transform.position, transform.rotation);
            }
         
            
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isShooting == false)
            {
                isShooting = true;
                StartCoroutine(WaitToFire());
                Instantiate(lightBullet, transform.position, transform.rotation * Quaternion.AngleAxis(180, transform.up));
            }
        }

    }//update

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(1);
        isShooting = false;
    }

    IEnumerator PlayerHurt()
    {
        yield return new WaitForSeconds(5);
        isHurt = false;
    }

    //Pickups and Collisons
    private void OnTriggerEnter(Collider other)
    {
        //This code is for the portals in game jumping to new levels in the scene
        if (other.gameObject.tag == "Portal")
        {
            transform.position = other.gameObject.GetComponent<Portal>().teleportPoint.transform.position;
            startPos = transform.position;
        }//portal

            //death
            if (other.gameObject.tag == "Death")
        {
            transform.position = startPos;
        }

        //damagesources
        if (isHurt == false)
        {
            //Enemy
            if (other.gameObject.tag == "Enemy")
            {
                Lives += -5;
                isHurt = true;
                StartCoroutine(PlayerHurt());

            }//enemy
        }
    }
    private void Jump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {

            rigidbodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }//jump


   

  
}
