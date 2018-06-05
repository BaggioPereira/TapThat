using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System;

public class Manager : MonoBehaviour {

    public GameObject MainCanvas, GameSelect;
    public GameObject Winning;
    public GameObject ScoreObject;
    int Score, TimerScore;
    float TimeLeft;
    public GameObject Menu, Game, TimerGame;
    public bool DebugLog;
    public bool[] GameSelected;

    // Use this for initialization
    void Start ()
    {
        if (Menu.active == true)
        {
            Time.timeScale = 0f;
        }
        GameSelected[0] = true;
        TimeLeft = 10.0f;
        Score = TimerScore = 0;
        ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score : " + Score.ToString();
        //nvokeRepeating("NewPoint", 0f, 0.001f);
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

        NewPoint();
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
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Selection()
    {
        Menu.SetActive(false);
        GameSelect.SetActive(true);
    }
    public void Back()
    {
        Menu.SetActive(true);
        GameSelect.SetActive(false);
    }

    public void Tapfinity()
    {
        for(int i = 0; i < GameSelected.Length; i++)
        {
            GameSelected[i] = false;
        }
        GameSelected[0] = true;
    }

    public void Taptime()
    {
        for (int i = 0; i < GameSelected.Length; i++)
        {
            GameSelected[i] = false;
        }
        GameSelected[1] = true;
    }

    public void Play()
    {
        Menu.SetActive(false);
        //Time.timeScale = 1f;
        //TimerGame.SetActive(true);
        Instantiate(TimerGame, Vector3.zero, Quaternion.identity).transform.parent = MainCanvas.transform;
    }
}
