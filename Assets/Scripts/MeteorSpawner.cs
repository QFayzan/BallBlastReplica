using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteorPrefabs;
    public float startDelay = 1.0f;
    public float repeatDelay = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteor", startDelay, repeatDelay);
    }
    void SpawnMeteor()
    {
        int index = Random.Range(0, meteorPrefabs.Length);
        Vector3 spawnLocation = new Vector3(Random.Range(-4,4),12, 0);
        Instantiate(meteorPrefabs[index], spawnLocation, meteorPrefabs[index].transform.rotation);
    }
}
