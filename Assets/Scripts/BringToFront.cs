using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour {

	//Forces panel to front, above layers
	void OnEnable(){
		//make it the last child in hierarchy so comes last, on top
		transform.SetAsLastSibling ();
	}
}
