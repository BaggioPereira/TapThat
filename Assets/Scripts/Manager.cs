using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Manager : MonoBehaviour {

    public GameObject Winning;
    public GameObject ScoreObject;
    int Score;

	// Use this for initialization
	void Start ()
    {
        Score = 0;
        ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score : " + Score.ToString();
        InvokeRepeating("NewPoint", 0f, 0.1f);
	}

    void NewPoint()
    {
        if(Winning.active == false)
        {
            Vector2 pos = new Vector2(Random.Range(-93, 94), Random.Range(-191, 141));
            Winning.GetComponent<RectTransform>().localPosition = pos;
            Winning.SetActive(true);
        }
    }

    public void Point()
    {
        Winning.SetActive(false);
        Score++;
        ScoreObject.GetComponent<TextMeshProUGUI>().text = "Score : " + Score.ToString();
    }
}
