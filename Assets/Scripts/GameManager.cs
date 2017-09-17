using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static GameManager _instance = null;

    // Use this for initialization
    void Start () {
        if (Instance)
            DestroyImmediate(gameObject);
        else
        {// new gameManager can be created to carry over fresh variable and progress levels
            Instance = this;

            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {

        //for (GameObject g; g.gameObject. > 0 ;)


        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name == "Start")
                SceneManager.LoadScene("Arena");
            if (SceneManager.GetActiveScene().name == "End")
                SceneManager.LoadScene("Start");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Start")
                Application.Quit();

            if (SceneManager.GetActiveScene().name == "End")
                SceneManager.LoadScene("Start");

            if (SceneManager.GetActiveScene().name == "Arena")
                SceneManager.LoadScene("Start");
        }
    }

    public void PlayFinal()
    {
        SceneManager.LoadScene("Arena");
    }

    public void StartOver()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("End");
    }

    public void Quit()
    {

        if (SceneManager.GetActiveScene().name == "Arena" || SceneManager.GetActiveScene().name == "Victory")
            SceneManager.LoadScene("Start");
        else if (SceneManager.GetActiveScene().name == "Start")
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }

    public static GameManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

}
