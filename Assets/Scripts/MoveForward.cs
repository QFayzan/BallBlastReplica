using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   public class MoveForward : MonoBehaviour
{
    //Move Forward Function
     private float topBound = 20f;
    public float speed = 40f;

    void Start()
    {
        GetComponent<TrailRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        
       Destroy(gameObject);
    }
}

