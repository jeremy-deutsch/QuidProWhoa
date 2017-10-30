using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTorch : MonoBehaviour {

	private float counter = 0.0f;

	private bool flaming = false;

	private Mixing mix;

	
	// Update is called once per frame
	void Update() {
		if (flaming) {
			if (counter <= 4) {
				counter += Time.deltaTime;
			}else if (counter < 6) {
				counter += Time.deltaTime;
				if (counter < 4.5) {
					counter += Time.deltaTime;
					//GetComponent <SpriteRenderer> ().sprite = Resources.Load<Sprite> ("fire" + 1);
				}else if (counter < 5) {
					counter += Time.deltaTime;
					//GetComponent <SpriteRenderer> ().sprite = Resources.Load<Sprite> ("fire" + 2);
				}else if (counter < 5.5) {
					counter += Time.deltaTime;
					//GetComponent <SpriteRenderer> ().sprite = Resources.Load<Sprite> ("fire" + 3);
				}
			} else if (counter >= 6) {
				Debug.Log ("Done Heating");
				flaming = false;
				mix.Action (Element.Fire);
			}
		}
	}

	void OnMouseUp () {
		if (counter >= 6f && mix != null) {
			counter = 0f;
			this.gameObject.SetActive (false);
			mix.EnableOnMix (this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Bucket")) {
			flaming = true;

			if (mix == null) {
				mix = other.GetComponent<Mixing> ();
			}
		}

	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Bucket")) {
			flaming = false;
		}
	}
}
