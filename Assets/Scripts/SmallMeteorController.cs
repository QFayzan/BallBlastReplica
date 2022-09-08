using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteorController : MonoBehaviour
{
    //an audio system to randomize different audio when destroyed
    private AudioSource popAudio;
    public AudioClip[]  popSound;
    public float fallSpeed =2.0f;
    public float fallFactor = 1.2f;
    public int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        popAudio = GetComponent<AudioSource>();
    }
    

    // Update is called once per frame
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
