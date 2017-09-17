using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForBall : MonoBehaviour {

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTrgggerStay(Collider c)
    {
        if (c.gameObject.tag == "gameBall")
        {
            Debug.Log("Another ball");
        }
    }
    
}
