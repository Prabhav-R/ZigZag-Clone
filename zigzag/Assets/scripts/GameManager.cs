using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameover;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        gameover = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Startgame()
    {
        ScoreManager.instance.Startscore();
        UiManager.instance.GameStart();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().startspawningplatforms();
    }
    public void StopGame()
    {
        gameover = true;
        ScoreManager.instance.Stopscore();
        UiManager.instance.GameOver();
    }
}
