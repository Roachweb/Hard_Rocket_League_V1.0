using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    static int _gameScore;

    public Text timerLabel;

    public Text scoreText;

    public static float countDown;

    static float _time;

    void Start ()
    {
        GameScore = 0;
        SetScore();

        countDown = 60;
    }

	void FixedUpdate ()
    {
        if ((SceneManager.GetActiveScene().name == "Arena"))
        {
            SetScore();

            GameTime = countDown - Time.time;

            var minutes = GameTime / 60;
            var seconds = GameTime % 60;
            var fraction = (GameTime * 100) % 100;

            timerLabel.text = string.Format("{0:00} : {1:00} ", minutes, seconds, fraction);

            if (GameTime <= 0)
            {
                SceneManager.LoadScene("End");
            }
        }
        else if(SceneManager.GetActiveScene().name == "End")
        {
            SetScore();    
        }
    }

    void SetScore()
    {
        scoreText.text = goalArea.score.ToString();
    }

    public static float GameTime
    {
        get { return _time; }
        set { _time = value;
            if (_time < 0)
            {
                _time = 0;
            }
        }
    }

    public int GameScore
    {
        get { return _gameScore; }
        set { _gameScore = value;  }
    }
}
