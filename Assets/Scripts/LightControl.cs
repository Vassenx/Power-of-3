using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {

    float nRand = 0;
	
	void Update ()
	{	
		//Created by TinyFire creater: Twelve (free from Unity Assets Store)
        nRand = Random.Range(4f, 6f);
        this.transform.GetComponent<Light>().intensity = nRand;
	}
}
