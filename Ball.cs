using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject particle;
    [SerializeField] private float speed;
    [SerializeField] private float fallSpeed;
    [SerializeField] AudioSource audioSource01;
    bool started;
    bool gameOver; 
    Rigidbody rigidBody;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

	void Start () {
        started = false; 
        gameOver = false;
	}

	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigidBody.velocity = new Vector3(speed, 0, 0);
                started = true;
                GameManager.instance.GameStart();
            }
        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f))
        {
            gameOver = true;
            rigidBody.velocity = new Vector3(0, -fallSpeed, 0);
            Destroy(gameObject, 1.0f);
            Camera.main.GetComponent<CameraHandle>().gameOver = true;
            GameManager.instance.GameOver();
        }
        if (Input.GetMouseButtonDown(0) && !gameOver)
        	{
            ScoreHandle.instance.IncrementScore();
            if (rigidBody.velocity.z > 0)
            rigidBody.velocity = new Vector3(speed, 0, 0);
            else if (rigidBody.velocity.x > 0)
            rigidBody.velocity = new Vector3(0, 0, speed);
        	}
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Diamond")
        {
            audioSource01.volume = 1f;
            audioSource01.Play();
            ScoreManager.instance.DiamondScore();
            GameObject part = Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(part, 1.0f); 
        }
    }
}
