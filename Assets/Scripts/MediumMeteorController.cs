using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MediumMeteorController : MonoBehaviour
{
    private AudioSource popAudio;
    public AudioClip[]  popSound;
    public GameObject smallMeteor;
    public TextMeshProUGUI ballHP;
    public float fallSpeed =1.5f;
    public float fallFactor = 0.9f;
    public int health = 1;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartSpeed();
    }
    

    // Update is called once per frame
    void Update()
    {
        ballHP.text = health.ToString(); 
        //transform.Translate(Vector3.back * Time.deltaTime * fallSpeed * fallFactor);
        if (health ==0 )
        {
            Die();
         AudioSource.PlayClipAtPoint(popSound[Random.Range(0,3)], this.gameObject.transform.position);
        }
         
    }
    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag=="Missile")
       {
        health--;
        gameObject.transform.localScale = transform.localScale - (new Vector3(0.8f,0.8f,0.8f));
       }
    }
    public void Die()
    {
        Vector3 spawnLocation1 = new Vector3(transform.position.x +1, transform.position.y , transform.position.z);
        Vector3 spawnLocation2 = new Vector3(transform.position.x -1, transform.position.y , transform.position.z);

        Instantiate(smallMeteor,spawnLocation1,transform.rotation);
        Instantiate(smallMeteor,spawnLocation2,transform.rotation);
        TimeManager.Counter += 2;
        Destroy(gameObject);
    }
    public void TakeDamage()
    {
         if (health < 1)
        {
            Die();
        }
    }
     void StartSpeed()
    {
        
        Vector3 direction = new Vector3 (Random.Range(-2,2),0,0);
        Vector3 direction2 = new Vector3 (-1,0,0);
        //rb.AddRelativeForce (direction * 30 - rb.velocity);
        rb.AddRelativeForce (direction * 100 - rb.velocity);
    }

}
