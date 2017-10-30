using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDragger : Draggable {

	public GameObject breakingIce;

	protected override void DroppedOn (Mixing other) {
		breakingIce.SetActive (true);
		this.gameObject.SetActive (false);
		ResetPosition ();
		other.EnableOnMix (this.gameObject);
	}
}
