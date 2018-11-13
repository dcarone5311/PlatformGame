using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;

public class Timer : MonoBehaviour {

    private float seconds;

    public Text text;

    void Awake()
    {
        //make the timer start at 0
        seconds = 0;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        seconds += Time.deltaTime; //deltaTime = "seconds it took to complete the last frame"

        string formattedString = seconds.ToString("N", CultureInfo.InvariantCulture);
        text.text = formattedString;


	}
}
