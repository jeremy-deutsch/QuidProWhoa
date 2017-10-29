using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTorch : MonoBehaviour {

	private float counter = 0.0f;

	//bool flaming = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseEnter () {
		Debug.Log ("Entered");
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log ("space is being pressed");
		}

	}	
	/*
	void Update() {
		if (flaming) {
			counter += Time.fixedDeltaTime;
			Debug.Log ("mouse is being held" + counter);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		flaming = true;
	}

	void OnTriggerExit2D (Collider2D other) {

	}*/
}
