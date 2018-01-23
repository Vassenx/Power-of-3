using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Game made by Samantha Difeo January 2018
//For Game Jam Monthly GameDevMcgill
public class Snowman : MonoBehaviour {

	public static float movSpeed = 30.0f;
	private float rotSpeed = 60.0f;

	void Update(){

		//forced position under terrain a little. Looks nicer
		float x = transform.position.x;
		float z = transform.position.z;
		if (80f < x && x < 425f && 80 < z && z < 405) {
			Vector3 ys = transform.position;
			ys.y = .6f;
			transform.position = ys;
		}

		//Movement wasd or arrows
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey( KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime * movSpeed);
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey( KeyCode.S)) {
			transform.Translate(Vector3.back * Time.deltaTime * movSpeed);
		}
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey( KeyCode.A )){
			transform.Rotate(Vector3.up * Time.deltaTime * -rotSpeed, Space.Self);	
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed, Space.Self);
		}

	}
}
