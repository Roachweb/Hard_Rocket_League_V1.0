using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalArea : MonoBehaviour {

    static int _score;

    bool jusSc;

    // Use this for initialization
    void Start () {
        if (score == 0)
        {
            score = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {

      
	}

    void OnTriggerEnter(Collider c)
    {
        if (jusSc == false)
        {
            if (c.gameObject.tag == "gameBall")
            {
                Debug.LogWarning("ScorePlus");

                score++;

                Debug.Log(score);

                jusSc = true;
            }//gameball     
        }//jus false
    }//enter


    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "gameBall")
        {
            Debug.Log("left");
            jusSc = false;
        }
    }
    public static int score
    {
        get { return _score; }
        set
        {
            _score = value;

            if (_score < 0)
            {
                score = 0;
            }
        }
    }
}
