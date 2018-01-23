using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
//Game made by Samantha Difeo January 2018
//For Game Jam Monthly GameDevMcgill
public class ModalWindow : MonoBehaviour {

	public Text question;
	public Button yesButton;
	public Button noButton;
	public GameObject modalPanelObject;

	private static ModalWindow modalWindow;

	//ModalWindow.Instance() will find and initalize a ModalWindow
	public static ModalWindow Instance(){
		if (!modalWindow) {
			modalWindow = FindObjectOfType (typeof(ModalWindow)) as ModalWindow;	
			if (!modalWindow) {
				Debug.LogError ("Needs to have one active ModalPanel script on a GameObject in your scene.");
			}
		}
		return modalWindow;
	}

	//Yes/No/Cancel: A string, a Yes event, a No event, a Cancel event
	public void Choice(string question){

		//result = UnityAction ((pointer))
		//must be attached to buttons... OnClick() event
		modalPanelObject.SetActive(true);
		yesButton.onClick.RemoveAllListeners();
		//dont want to call from last time used it if button is used many times
		//yesButton.onClick.AddListener(yesEvent);
		//when click yes, will close window
		yesButton.onClick.AddListener (ClosePanel);

		noButton.onClick.RemoveAllListeners();
		//noButton.onClick.AddListener (noEvent);
		noButton.onClick.AddListener (ClosePanel);

		//question text always on
		this.question.text = question;
		yesButton.gameObject.SetActive (true);
		noButton.gameObject.SetActive (true);

	}

	void ClosePanel(){
		modalPanelObject.SetActive (false);
	}
}
