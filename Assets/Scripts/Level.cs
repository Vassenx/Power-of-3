using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
	public GameObject modalPanelObject;

	public void LoadScene (string name) {
		SceneManager.LoadScene (name);

	}
	public void RageQuit(){
		Application.Quit ();
	}
	//Closes the panel if this button is pressed (No button on panel uses this)
	public void ClosePanel(GameObject modalPanelObject){
		modalPanelObject.SetActive (false);
	}
}
