using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDragger : Draggable {

	protected override void DroppedOn (Mixing other) {
		transform.position = other.transform.position + new Vector3 (0f, 0.5f);
		// TODO: Initiate ice cracking
		this.enabled = false; // disable the Draggable script
	}
}
