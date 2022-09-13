using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteorPrefabs;
    public float startDelay = 1.0f;
    public float repeatDelay = 3.0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        InvokeRepeating("SpawnMeteor", startDelay, repeatDelay);
    }
    void SpawnMeteor()
    {
        int index = Random.Range(0, meteorPrefabs.Length);
        Vector3 spawnLocation = new Vector3(Random.Range(-4,4),12, 0);
        var instance = Instantiate(meteorPrefabs[index], spawnLocation, meteorPrefabs[index].transform.rotation);
        instance.GetComponent<Rigidbody>().AddForce(spawnLocation * 10);
    }
}
