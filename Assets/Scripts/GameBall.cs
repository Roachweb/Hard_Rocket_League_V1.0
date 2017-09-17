using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall : MonoBehaviour {

    Rigidbody rb;

    GameObject Goal;

    GameObject reSpawnPoint;

    bool respawned;

    Transform setPT;

    Vector3 velocity = Vector3.zero;

    

    // Use this for initialization
    void Start () {
        reSpawnPoint = GameObject.FindGameObjectWithTag("reSpawnPoint");

        Goal = GameObject.FindGameObjectWithTag("Goal");

        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.M))
        {
            Reset();
        }
        //Debug.Log(transform.position.Set);

       
      
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player") 
        {
            velocity = new Vector3(0, 80 * Time.deltaTime, 0);
            transform.position += velocity;
            
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject == Goal)
        { 
            Debug.LogWarning("Point Hype"); 
        }  
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "goal")
        {
            Reset();
        }
    }

    void Reset()
    {
        setPT = reSpawnPoint.transform;

        transform.position = setPT.transform.position;
        transform.rotation = reSpawnPoint.transform.rotation;

        rb.MovePosition(setPT.transform.position + transform.up * Time.deltaTime);
    }
}
