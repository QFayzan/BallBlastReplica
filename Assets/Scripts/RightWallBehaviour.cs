using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag=="Enemy")
       {
        collision.gameObject.GetComponent<Rigidbody>();
    
        collision.rigidbody.AddRelativeForce (Vector3.left * 50);
       }
    }
}
