using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerDragger : Draggable {

	public ShakerShaker actualShaker;

	protected override void DroppedOn (Mixing other) {
		transform.position = other.transform.position + new Vector3 (0f, 0.5f);
		// TODO: Initiate shaking
		actualShaker.SetMixing (other);
		actualShaker.gameObject.SetActive (true);
		this.gameObject.SetActive (false); // disable the Draggable script
	}
}
