using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContoller : MonoBehaviour {

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
            }
        }

        if(!Physics.Raycast(transform.position, Vector3.down, 1f)){
            gameOver = true;
        }


        //left click
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
}
