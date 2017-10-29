using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Draggable {

	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void DroppedOn (Mixing other) {
		this.ResetPosition ();
		other.Drop (this.GetComponent<Naming> ());
	}
}
