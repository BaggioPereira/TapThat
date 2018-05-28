using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Manager : MonoBehaviour {

    public GameObject Winning;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("NewPoint", 0f, 0.1f);
	}

    void NewPoint()
    {
        if(Winning.active == false)
        {
            Vector2 pos = new Vector2(Random.Range(-93, 94), Random.Range(-191, 192));
            Winning.GetComponent<RectTransform>().localPosition = pos;
            Winning.SetActive(true);
        }
    }

    public void Point()
    {
        Winning.SetActive(false);
    }
}
