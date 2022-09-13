using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteorController : MonoBehaviour
{
    //an audio system to randomize different audio when destroyed
    private AudioSource popAudio;
    public AudioClip[]  popSound;
    private Vector3 startForce = new Vector3(0,0,1);
    public float fallSpeed =2.0f;
    public float fallFactor = 1.2f;
    public int health = 1;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= gameObject.GetComponent<Rigidbody>();
        popAudio = GetComponent<AudioSource>();
        StartSpeed();
        //rb.AddRelativeForce (Vector3.right * 10 - rb.velocity);
    }
    
    void Update()
    {
        //transform.Translate(Vector3.back * Time.deltaTime * fallSpeed * fallFactor);
        if (health ==0 )
        {
            Die();
        AudioSource.PlayClipAtPoint(popSound[Random.Range(0,3)], this.gameObject.transform.position);
        //popAudio.clip = popSound[Random.Range(0,popSound.Length)];
        }
         
    }
    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag=="Missile")
       {
        health--;
        
       }
    }
    void StartSpeed()
    {
        
        Vector3 direction = new Vector3 (Random.Range(-2,2),0,0);
        Vector3 direction2 = new Vector3 (-1,0,0);
        //rb.AddRelativeForce (direction * 30 - rb.velocity);
        rb.AddRelativeForce (direction * 80 - rb.velocity);
    }
    public void Die()
    {
       Destroy(gameObject);
    }
    public void TakeDamage()
    {
         if (health < 1)
        {
            Die();
        }
    }
    

}
