using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System;

public class Manager : MonoBehaviour {

    public GameObject Winning, TimerWinning;
    public GameObject ScoreObject;
    public GameObject Timer;
    int Score, TimerScore;
    float TimeLeft;

    public GameObject Menu, Game, TimerGame, TimeGamePanel, ScorePanel;
    public bool DebugLog;

    // Use this for initialization
    void Start ()
    {
        if (Menu.active == true)
        {
            Time.timeScale = 0f;
        }
        TimeLeft = 10.0f;
        Score = TimerScore = 0;
        ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score : " + Score.ToString();
        InvokeRepeating("NewPoint", 0f, 0.1f);
	}

    void Update()
    {
        if (DebugLog)
        {
            Debug.Log(Time.timeScale);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(TimerScore > 0)
        {
            Time.timeScale = 1f;
            TimeLeft -= Time.deltaTime;
            TimeLeft = (float)Math.Round(TimeLeft, 2);
            Timer.GetComponent<TextMeshProUGUI>().text = TimeLeft.ToString();
        }

        if(TimeLeft <= 0.0f)
        {
            Time.timeScale = 0f;
            TimeGamePanel.SetActive(false);
            ScorePanel.SetActive(true);
        }
    }

    void NewPoint()
    {
        if (Game.active == true)
        {
            if (Winning.active == false)
            {
                Vector2 pos = new Vector2(UnityEngine.Random.Range(-93, 94), UnityEngine.Random.Range(-191, 141));
                Winning.GetComponent<RectTransform>().localPosition = pos;
                Winning.SetActive(true);
            }
        }

        else if (TimerGame.active == true)
        {
            if (TimerWinning.active == false)
            {
                Vector2 pos = new Vector2(UnityEngine.Random.Range(-93, 94), UnityEngine.Random.Range(-191, 141));
                TimerWinning.GetComponent<RectTransform>().localPosition = pos;
                TimerWinning.SetActive(true);
            }
        }
    }

    public void Point()
    {
        TimerWinning.SetActive(false);
        TimerScore++;
        //ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score : " + Score.ToString();
    }

    public void Play()
    {
        Menu.SetActive(false);
        //Time.timeScale = 1f;
        TimerGame.SetActive(true);
    }
}
