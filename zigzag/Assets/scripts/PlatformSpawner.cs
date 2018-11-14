using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    float size;
    Vector3 lastPos;
    public bool gameOver;

    public GameObject diamond;

	// Use this for initialization
	void Start () {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        for(int i = 0; i < 20; i++)
        {
            Spawner();
        }
        
	}

    public void startspawningplatforms()
    {
        InvokeRepeating("Spawner", 0.1f, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameover==true)
        {
            CancelInvoke("Spawner");
        }
	}

    void Spawner()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x,pos.y+1,pos.z),diamond.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
    
}
