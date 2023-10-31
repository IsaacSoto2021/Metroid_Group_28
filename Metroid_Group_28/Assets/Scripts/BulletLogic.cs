using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 startPos;

    private void Start()
    {
         
      startPos = transform.position;

        StartCoroutine(WaitToVanish());
    }


    IEnumerator WaitToVanish()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

   
}
