using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;

    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text highScore;
    public Text bestscore;
    public Text score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        highScore.text = "High Score : " + PlayerPrefs.GetInt("highscore").ToString();
	}

    public void GameStart()
    {
        tapText.SetActive(false);
        gamePanel.GetComponent<Animator>().Play("panelUp");
    }
	
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        bestscore.text = PlayerPrefs.GetInt("highscore").ToString();

        gameOverPanel.SetActive(true);

    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
