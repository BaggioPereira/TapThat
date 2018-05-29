using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {
    public GameObject Menu, Game, TimerGame;
    public bool DebugLog;
	// Use this for initialization
	void Start ()
    {
		if(Menu.active == true)
        {
            Time.timeScale = 0f;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(DebugLog)
        {
            Debug.Log(Time.timeScale);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void Play()
    {
        Menu.SetActive(false);
        //Time.timeScale = 1f;
        TimerGame.SetActive(true);
    }
}
