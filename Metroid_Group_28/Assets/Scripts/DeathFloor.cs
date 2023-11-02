using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
           PlayerController Samus = other.gameObject.GetComponent<PlayerController>();
           if (Samus != null)
           {
            other.gameObject.transform.position = Samus.startPos;
            print ("Meow");
           }
          
        }




    }




}
