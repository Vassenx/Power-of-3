using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	//3 mins + 1 second as it takes a second to load
	public static float timeLeft = 181f;
	//Timer and log count text
	public Text text;

	void Awake(){
		//Each change to this scene will reset the timer and log count
		timeLeft = 181f;
		Collection.count = 0;
	}

	void FixedUpdate(){
	    //Timer in minutes
		timeLeft = timeLeft - Time.deltaTime;
		int minutes = (int)(timeLeft / 60);
		int seconds = (int)(timeLeft % 60);
		//Forced font, not sure why it was not working manually on text
		text.fontSize = 80;
		text.text = minutes + ":" + seconds + " time left!\n " + Collection.count + " logs";
	}

	void Update(){
		//End, time up
		if (timeLeft <= 0) {
			SceneManager.LoadSceneAsync ("Lose");
		}
	}
}

