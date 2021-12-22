using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandle : MonoBehaviour {

    public static ScoreManager instance;
    public int score;
    public int highScore;
    [SerializeField] private Text scoreText;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    private void Update() {
        scoreText.text = score.ToString("0");
    }


    public void StopScore()
    {
        PlayerPrefs.SetInt("score", score); 
        if (PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore")) 
            {
                PlayerPrefs.SetInt("highScore", score); 
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void IncrementScore()
    {
        score += 1;
    }

    public void DiamondScore()
    {
        score += 10;
    }
}