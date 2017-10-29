using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTorchDragger : Draggable {
	protected override void DroppedOn (Mixing other) {
		ResetPosition ();
	}


}
