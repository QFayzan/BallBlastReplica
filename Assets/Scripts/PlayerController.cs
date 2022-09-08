using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xRange = 11.0f; // designed to keep player in x and -x range its y will be frozen in rigidbody
    public float horizontalInput; //Getting Horizontal input for Player
    public float moveSpeed; //Player's Movespeed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //X range movement check 
         if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            //Horizontal Input initialization
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
    }
    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag=="Enemy")
       {
        TimeManager.Counter -=10;
        
       }
    }
}
