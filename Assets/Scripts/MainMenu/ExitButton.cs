using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	void Update() {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	void OnMouseUpAsButton() {
		Application.Quit ();
	}
}
