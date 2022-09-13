using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI hpRemaining;  // hp display method
    public float xRange = 11.0f; // designed to keep player in x and -x range its y will be frozen in rigidbody
    public float horizontalInput; //Getting Horizontal input for Player
    public float moveSpeed; //Player's Movespeed
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip painSound;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private static int health = 3; //working with health
    public bool isOnGround = true;//required for ground particle
    public bool gameOver = false; // required for game over animation
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if (health <1)
        {
            Die();
        }
        hpRemaining.text = "Health remaining : " + health.ToString();
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
            transform.Rotate(new Vector3(0,90,0), horizontalInput * Time.deltaTime, Space.Self);
    }
    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag=="Enemy")
       {
        AudioSource.PlayClipAtPoint(painSound, this.gameObject.transform.position);
        TimeManager.Counter -=10;
        health--;

       }
       else if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround= true;
            dirtParticle.Play();
        }
       
    }
    void Die()
    {
          dirtParticle.Stop();
          playerAnim.SetBool("IsDead", true);
          playerAnim.SetInteger("DeathType_int", 1);
          AudioSource.PlayClipAtPoint(crashSound, this.gameObject.transform.position);
          gameOver = true;
    }
}
