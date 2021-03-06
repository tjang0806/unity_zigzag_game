﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContoller : MonoBehaviour {

    public GameObject particle;

    [SerializeField]
    private float speed;
    bool started;
    bool gameOver;


    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        started = false;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

        // case game not started
        if(!started){
            if(Input.GetMouseButtonDown(0)){
                rb.velocity = new Vector3(speed, 0, 0);

                //change boolean value so that if statement does not trigger
                started = true;

                GameManager.instance.StartGame();
            }
        }

        //Debug.DrawRay(transform.position, Vector3.down, Color.red);

        // gameover case
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();
        }

        //left click and the ball change direction
        if(Input.GetMouseButtonDown(0) && !gameOver){
            SwitchDirection();
        }
	}

    //every time the function is called, unity picks differenct if statement
    void SwitchDirection(){
        if(rb.velocity.z > 0){
            rb.velocity = new Vector3(speed, 0, 0);
        } else if(rb.velocity.x >0){
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // other is diamond
        // part is particle
        if(other.gameObject.tag == "Diamond"){
            GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(other.gameObject);
            Destroy(part, 0.2f);
        }
    }
}
