using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerDragger : Draggable {

	public ShakerShaker actualShaker;

	void OnEnable () {
		//actualShaker.gameObject.SetActive (false);
	}

	protected override void DroppedOn (Mixing other) {
		transform.position = other.transform.position + new Vector3 (0f, 0.5f);
		// Initiate shaking
		actualShaker.SetMixing (other);
		actualShaker.gameObject.SetActive (true);
		this.gameObject.SetActive (false); // disable the Draggable script
		ResetPosition ();
		other.EnableOnMix (this.gameObject);
	}
}
