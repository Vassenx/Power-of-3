using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Game made by Samantha Difeo January 2018
//For Game Jam Monthly GameDevMcgill
public class Spawn : MonoBehaviour {

	//Log or Fire. Dimensions of the playable terrain
	float LogZb = 405.0f;
	float LogZa = 75.0f;
	float LogXb = 425.0f;
	float LogXa = 75.0f;

	float lastSpawn;

 	void Start () {
		lastSpawn = Time.time;
	}
		
	void newLogs(){

		float LogZ = Random.Range(LogZa, LogZb);
		float LogX = Random.Range(LogXa, LogXb);
		Vector3 logPosition = new Vector3(LogX, 0.5f, LogZ);

		Instantiate(GameObject.FindGameObjectWithTag("Log"), logPosition, Quaternion.identity);
			
	}
	void newFires(){

		float LogZ = Random.Range(LogZa, LogZb);
		float LogX = Random.Range(LogXa, LogXb);
		Vector3 logPosition = new Vector3(LogX, 0.5f, LogZ);

		Instantiate(GameObject.FindGameObjectWithTag("TinyFire"), logPosition, Quaternion.identity);

	}

	void Update () {

		//Every 2.5 seconds make 4 fires and 1 log
		if (Time.time - lastSpawn > 2.5) {

			newFires ();
			newFires ();
			newLogs ();
			newFires ();
			newFires ();

			lastSpawn = Time.time;

		}
	}
}
