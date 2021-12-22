using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;
    Vector3 lastPosition;
    float size;
	void Start () {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x;
        for (int i = 0; i < 20; i++)
            makePlatform();
	}
	
	void Update () {
        if (GameManager.instance.gameOver == true)
            CancelInvoke("makePlatform");
	}
    
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("makePlatform", 0.1f, 0.2f);
    }

    void makePlatform()
    {
        int rand = Random.Range(0, 8);
        if (rand < 4)
            makeX();
        else if (rand >= 4)
            makeZ();
    }

    void makeX()
    {
        Vector3 pos = lastPosition;
        pos.x += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;
        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
    }

    void makeZ()
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;
        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
    }
}
