using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Advertisements;

public class TimerGame : MonoBehaviour {
    #if UNITY_IOS
    private string gameID = "2593061";
    #elif UNITY_ANDROID
    private string gameID = "2593063";
    #endif

    public GameObject WinningObject, ScoreObject, GameDisplay, ScoreDisplay, Timer;
    float TimeLeft;
    int Score = 0;
	// Use this for initialization
	void Start ()
    {
        Advertisement.Initialize(gameID);
        Time.timeScale = 0;
        TimeLeft = 10.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        NewPoint();

        if (Score > 0)
        {
            Time.timeScale = 1f;
            TimeLeft -= Time.deltaTime;
            float Display = Mathf.Round(TimeLeft);
            //TimeLeft = (float)Math.Round(TimeLeft, 2);
            Timer.GetComponent<TextMeshProUGUI>().text = Display.ToString();
        }

        if (TimeLeft <= 0.0f)
        {
            Time.timeScale = 0f;
            GameDisplay.SetActive(false);
            ScoreDisplay.SetActive(true);
            ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score: " + Score;
            Advertisement.Show();
        }
    }
    void NewPoint()
    {
        if (WinningObject.active == false)
        {
            Vector2 pos = new Vector2(UnityEngine.Random.Range(-93, 94), UnityEngine.Random.Range(-191, 141));
            WinningObject.GetComponent<RectTransform>().localPosition = pos;
            WinningObject.SetActive(true);
        }
    }

    public void Point()
    {
        WinningObject.SetActive(false);
        Score++;
        //ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score : " + Score.ToString();
    }

    public void Restart()
    {
        Destroy(gameObject);
        GameObject.Find("Game Manager").GetComponent<Manager>().Play();
    }

    public void Quit()
    {
        Destroy(gameObject);
        GameObject.Find("Game Manager").GetComponent<Manager>().Menu.SetActive(true);
    }
}
