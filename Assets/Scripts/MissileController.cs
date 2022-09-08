using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
   
    public GameObject missilePrefab; //gets the missile prefab to launch
    public float missileDelay =0.1f; //Delay between lauching each missile
    public bool doSpawn = true; // DoSpawn true is used to check the limit of missiles spawned
    //Move the missile Forward Function
     
     
    
    void Update()
    {
        missileDelay = missileDelay + Time.deltaTime;
        if (missileDelay > 0.1f)
        {
            doSpawn = true;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && doSpawn)
        {
            Instantiate(missilePrefab, transform.position, missilePrefab.transform.rotation);
            doSpawn = false;
            missileDelay = 0;
        }
    }
}
