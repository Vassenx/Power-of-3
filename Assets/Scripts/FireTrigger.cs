using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider cot){
		//If hit fire, lose 27 seconds of game time
		if(cot.gameObject.tag == "Player"){
			Timer.timeLeft = Timer.timeLeft - 27.0f;
		}
	}
}
