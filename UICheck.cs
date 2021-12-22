using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICheck : MonoBehaviour {

    public static UiManager instance;
    public GameObject title;
    public GameObject page;
    public GameObject gameOver;
    public GameObject tap;
    public Text score;
    public Text highScore1;
    public Text highScore2;

    void Awake()
    {
        if (instance == null) 
            instance = this; 
    }

	void Start () {
        highScore1.text = "Record: " + PlayerPrefs.GetInt("highScore");
    }


    public void GameStart()
    {
        page.SetActive(false);
        tap.SetActive(false);
        title.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOver.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
