using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// Remstedt, Reed
// 11/8/2023
// player controller, handles movement, health, and Shooting
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 1f;

    private Rigidbody rigidbodyRef;
    public Vector3 startPos;
    public int lives = 99;

    public GameObject lightBullet;
    public GameObject heavyBullet;

    private bool isShooting = false;
    public bool isHurt = false;

    private bool heavyBulletFound = false;

    public MeshRenderer MeshRenderer;


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
                if (heavyBulletFound)
                {
                    Instantiate(heavyBullet, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(lightBullet, transform.position, transform.rotation);
                }
            }
         
            
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isShooting == false)
            {
                isShooting = true;
                StartCoroutine(WaitToFire());
                if (heavyBulletFound)
                {
                    Instantiate(heavyBullet, transform.position, transform.rotation * Quaternion.AngleAxis(180, transform.up));
                }
                else
                {
                    Instantiate(lightBullet, transform.position, transform.rotation * Quaternion.AngleAxis(180, transform.up));
                }
            }
        }

    }//update

    //corutines 

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    IEnumerator PlayerHurt()
    {
       for (int index = 0; index < 50; index++)
        {
            if (index % 2 == 0)
            {
                MeshRenderer.enabled = false;
            }
            else
            {
                MeshRenderer.enabled = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
        MeshRenderer.enabled = true;
       
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

        //End game portal
        if (other.gameObject.tag == "PortalHome")
        {

          SceneManager.LoadScene(0);

        }
        if (other.gameObject.tag == "Health")
        {
           lives += 35;
           if (lives > 99)
           {
               lives = 99;
           }

        }//Health

         if (other.gameObject.tag == "Health+")
        {
           
               lives = 199;
           

        }//Health+

        if (other.gameObject.tag == "Ammo")
        {
            heavyBulletFound = true;
        }

            //death
            if (other.gameObject.tag == "Death")
            {
             lives += -15;
             transform.position = startPos;
            }

        //damagesources
       
            //Enemy
            if (other.gameObject.tag == "Enemy")
            {
                if (isHurt == false)
                {
                 isHurt = true;
                 lives += -15;
               
                 StartCoroutine(PlayerHurt());
                }
            }//enemy

            if (other.gameObject.tag == "EnemyHard")
            {
                if (isHurt == false)
                {
                 isHurt = true;
                 lives += -35;
               
                 StartCoroutine(PlayerHurt());
                }
            }//enemy


        
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
