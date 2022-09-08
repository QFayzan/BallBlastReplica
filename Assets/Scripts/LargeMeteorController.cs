using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LargeMeteorController : MonoBehaviour
{
    private AudioSource popAudio;
    public AudioClip[]  popSound;
    private TimeManager TimeManagerscript;
    public GameObject mediumMeteor;
    public TextMeshProUGUI ballHP;
    public float fallSpeed =4.0f;
    public float fallFactor = 0.7f;
    public int health = 4;
    // Start is called before the first frame update
    void Start()
    {
        TimeManagerscript = GameObject.Find("TimeManager").GetComponent<TimeManager>();
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
        gameObject.transform.localScale = transform.localScale - (new Vector3(0.4f,0.4f,0.4f));
       }
    }
    public void Die()
    {
        Vector3 spawnLocation = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        Instantiate(mediumMeteor,spawnLocation,transform.rotation);
        Instantiate(mediumMeteor,spawnLocation,transform.rotation);
        TimeManager.Counter += 10;
       
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
