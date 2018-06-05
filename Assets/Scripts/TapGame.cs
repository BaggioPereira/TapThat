using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TapGame : MonoBehaviour {
    public GameObject GameDisplay, GameOverDisplay, WinningObject, GameOverObject, ScoreObject, GameOverScore;
    int Score = 0;
    float TimeLeft = 1f;
    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 0;
        ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score: " + Score;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (Score > 0)
        //{
        //    Time.timeScale = 1f;
        //}

        NewPoint();

        if(TimeLeft > 0f)
        {
            BadCounter();
        }
    }

    void NewPoint()
    {
        if (Time.timeScale == 1f)
        {
            int i = Random.Range(0, 2);
            if (GameOverObject.active == false && WinningObject.active == false)
            {
                if (i == 0)
                {
                    if (GameOverObject.active == false)
                    {
                        Vector2 pos = new Vector2(UnityEngine.Random.Range(-93, 94), UnityEngine.Random.Range(-191, 141));
                        GameOverObject.GetComponent<RectTransform>().localPosition = pos;
                        GameOverObject.SetActive(true);
                        TimeLeft = 1f;
                        BadCounter();
                    }
                }

                else if (i == 1)
                {
                    if (WinningObject.active == false)
                    {
                        Vector2 pos = new Vector2(UnityEngine.Random.Range(-93, 94), UnityEngine.Random.Range(-191, 141));
                        WinningObject.GetComponent<RectTransform>().localPosition = pos;
                        WinningObject.SetActive(true);
                    }
                }
            }
        }
    }

    void BadCounter()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0f)
        {
            GameOverObject.SetActive(false);
            NewPoint();
        }
    }

    public void Point()
    {
        WinningObject.SetActive(false);
        Score++;
        if (Score > 0)
        {
            Time.timeScale = 1f;
        }
        ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score: " + Score;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameDisplay.SetActive(false);
        GameOverDisplay.SetActive(true);
        GameOverScore.GetComponent<TextMeshProUGUI>().text = "Score: " + Score;
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
