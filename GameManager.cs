using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	void Start () {
        gameOver = false;		
	}
	

    public void GameStart()
    {
        GameObject.Find("makeSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
    }

    public void GameOver()
    {
        ScoreManager.instance.StopScore();
        gameOver = true;
    }

}
