using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public GameObject ball;
    public bool gameOver;
    public float lerpRate;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        gameOver = false;
        offset = ball.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!Physics.Raycast(ball.transform.position, Vector3.down, 1f))
        {
            gameOver = true;
        }
        if (!gameOver)
        {
            Follow();
        }
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}