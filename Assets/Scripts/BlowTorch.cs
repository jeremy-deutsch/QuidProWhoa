using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTorch : MonoBehaviour {

	private float counter = 0.0f;

	private bool flaming = false;

	
	// Update is called once per frame
	void Update() {
		if (flaming) {
			if (counter <= 5) {
				counter += Time.deltaTime;
				Debug.Log ("mouse is being held" + counter);
			} else if (counter > 5) {
				Debug.Log ("Done Heating");
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Bucket")) {
			flaming = true;
		}

	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Bucket")) {
			flaming = false;
		}
	}
}
