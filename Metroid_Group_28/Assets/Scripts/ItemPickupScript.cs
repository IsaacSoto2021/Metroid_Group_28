using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public Vector3 spinDirection = Vector3.zero;
    public float spinSpeed = 20f;



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinDirection * spinSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
