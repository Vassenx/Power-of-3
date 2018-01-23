using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Game made by Samantha Difeo January 2018
//For Game Jam Monthly GameDevMcgill
public class Trees : MonoBehaviour {

	private IEnumerator OnTriggerEnter(Collider cot){
		if (cot.gameObject.tag == "Player") {
			//Little arm animations on trees that "grab" the player
			GetComponent<Animation> ().Play ();
			Snowman.movSpeed -= 10f;
			//Wait 9 seconds. Movement only affected for 9 secs
			yield return new WaitForSeconds (9f);
			Snowman.movSpeed += 10f;
		}
	}
}
