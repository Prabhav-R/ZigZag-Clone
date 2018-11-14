﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour {

    public GameObject particle;

    [SerializeField]
    private float speed;
    Rigidbody rb;
    bool started;
    public bool gameOver;
    public cameraFollow cm;

    private void Awake()
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
        if(!started && Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector3(0, 0, speed);
            started = true;
            GameManager.instance.Startgame();
        }

        //Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            GameManager.instance.StopGame();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            switchDirection();       
        }
	}

    void switchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "diamond")
        {
            GameObject part = Instantiate(particle, coll.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(coll.gameObject);
            Destroy(part, 1.1f);
        }
    }
}
