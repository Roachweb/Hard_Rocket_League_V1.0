using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour {

    public GameObject Ball;

    public GameObject[] ranSpawn;
    //public spawnPoint coinPrefab;

    GameObject SpawnPoint;
    
    // Use this for initialization
    void Start () {

        SpawnPoint = ranSpawn[Random.Range(0, ranSpawn.Length)];
        Instantiate(SpawnPoint, this.transform.position, this .transform.rotation);

    }
	
	// Update is called once per frame
	void Update () {

    }

 
}
