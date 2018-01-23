using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Game made by Samantha Difeo January 2018
//For Game Jam Monthly GameDevMcgill
public class Collection : MonoBehaviour {

	public static int count;
	private int maxCount = 9; 
	public GameObject collection;
	Collider cd;
	//cded = collided with the log, don't collide with other logs yet
	bool cded = false;
	//cabined means collided with box, can spawn cabin piece
	bool cabined = false;
	Collision co;

	//Cabin parts
	GameObject[] parts, parts1, parts2, parts3, parts4, parts5;
	GameObject windowL, windowR, door, roof;

	//Panel asking to go to win scene or not
	GameObject panel;

	void Awake(){
		//Find parts, then deactive as can't find parts once they are deactived
		parts = GameObject.FindGameObjectsWithTag ("Back");
		parts1 = GameObject.FindGameObjectsWithTag ("Left");
		parts2 = GameObject.FindGameObjectsWithTag ("Right");
		parts3 = GameObject.FindGameObjectsWithTag ("Front");
		parts4 = GameObject.FindGameObjectsWithTag ("LeftTop");
		parts5 = GameObject.FindGameObjectsWithTag ("RightTop");
		windowL = GameObject.FindGameObjectWithTag ("WindowL");
		windowR = GameObject.FindGameObjectWithTag ("WindowR");
		door = GameObject.FindGameObjectWithTag ("Door");
		roof = GameObject.FindGameObjectWithTag ("Roof");
		panel = GameObject.Find ("ModalDialogPanel");

		panel.SetActive (false);

		for (int i = 0; i < parts.Length; i++) {
			parts [i].SetActive (false);
		}
		for (int i = 0; i < parts1.Length; i++) {
			parts1 [i].SetActive (false);
		}
		for (int i = 0; i < parts2.Length; i++) {
			parts2 [i].SetActive (false);
		}
		for (int i = 0; i < parts3.Length; i++) {
			parts3 [i].SetActive (false);
		}
		for (int i = 0; i < parts4.Length; i++) {
			parts4 [i].SetActive (false);
		}
		for (int i = 0; i < parts5.Length; i++) {
			parts5 [i].SetActive (false);
		}
		windowL.SetActive (false);
		windowR.SetActive (false);
		roof.SetActive (false);
		door.SetActive (false);

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Log") {

			//cded = true means have an object to pick up. Only 1 at a time
			if (cded == false) {
				co = col;
				cded = true;
			}
				
		}
		if (col.gameObject.tag == "cabin") {

			//If carrying an object, set cabin to true. 
			//Will cause a cabin part to spawn (in update function)
			if (cded == true) {
				cded = false;
				cabined = true;
			}
		}

	}

	void Update () {

		//Press Q to open panel to go to win screen
		if (count >= maxCount) {
			Timer.timeLeft = 181f;
			if (Input.GetKeyDown (KeyCode.Q)) {
				panel.SetActive (true);
			}
		}

		//Collided with log, so place in players hand
		if (cded == true) {
			Vector3 arm = collection.transform.position;
			Quaternion armR = collection.transform.rotation;

			co.gameObject.transform.position = arm;
			co.gameObject.transform.rotation = armR;

			cd = co.gameObject.GetComponent<Collider> ();
			cd.isTrigger = true;
		}

		//Spawn cabin if cabined label true (have log and placed log in box)
		if (cabined == true){
			co.gameObject.SetActive (false);

			count++; 
			logCabinSpawn ();

			cabined = false;
		}

	}
	void logCabinSpawn(){

		//Depending on count number, spawn the correct part of the log cabin
		if (count == 1) {
			for (int i = 0; i < parts.Length; i++) {
				parts [i].SetActive (true); 
			}
		}
		if (count == 2) {
			for (int i = 0; i < parts1.Length; i++) {
				parts1 [i].SetActive (true); 
			}
		}
		if (count == 3) {
			for (int i = 0; i < parts2.Length; i++) {
				parts2 [i].SetActive (true); 
			}
		}
		if (count == 4) {
			for (int i = 0; i < parts3.Length; i++) {
				parts3 [i].SetActive (true); 
			}
		}
		if (count == 5){
			roof.SetActive (true);
		}
		if (count == 6) {
			for (int i = 0; i < parts4.Length; i++) {
				parts4 [i].SetActive (true); 
			}
			for (int i = 0; i < parts5.Length; i++) {
				parts5 [i].SetActive (true); 
			}
		}
		if (count == 7) {
			windowL.SetActive (true);
		}
		if (count == 8) {
			windowR.SetActive (true);
		}
		if (count == 9) {
			door.SetActive (true);
		}

		//Won! Panel pops up
		if (count == maxCount) {
			panel.SetActive (true);

		}

	}
}
