using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System;

public class Manager : MonoBehaviour {

    public GameObject MainCanvas, GameSelect;
    public GameObject Menu;
    public bool DebugLog;
    public bool[] GameSelected;
    public GameObject[] Games;

    // Use this for initialization
    void Start ()
    {
        if (Menu.active == true)
        {
            Time.timeScale = 0f;
        }

        if (!PlayerPrefs.HasKey("GameID"))
        {
            PlayerPrefs.SetInt("GameID", 0);
            GameSelected[0] = true;
        }

        else if(PlayerPrefs.HasKey("GameID"))
        {
            GameSelected[PlayerPrefs.GetInt("GameID")] = true;
        }
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
        PlayerPrefs.SetInt("GameID", 0);
    }

    public void Taptime()
    {
        for (int i = 0; i < GameSelected.Length; i++)
        {
            GameSelected[i] = false;
        }
        GameSelected[1] = true;
        PlayerPrefs.SetInt("GameID", 1);
    }

    public void Play()
    {
        Menu.SetActive(false);
        if (PlayerPrefs.HasKey("GameID"))
            Instantiate(Games[PlayerPrefs.GetInt("GameID")], Vector3.zero, Quaternion.identity).transform.parent = MainCanvas.transform;
        //Time.timeScale = 1f;
        //TimerGame.SetActive(true);
        //Instantiate(TimerGame, Vector3.zero, Quaternion.identity).transform.parent = MainCanvas.transform;
    }
}
