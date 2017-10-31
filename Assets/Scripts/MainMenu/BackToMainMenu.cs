using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenu");
		}
	}

	void OnMouseUpAsButton() {
		SceneManager.LoadScene ("MainMenu");
	}
}
