using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerShaker : Draggable {

	public ShakerDragger dragShaker;
	public float howFarToShake = 50f;

	private Mixing mixingBowl;
	private float distanceTraveled;
	private Vector3 lastPlace = Vector3.zero;

	// Use this for initialization
	void Awake() {
		this.gameObject.SetActive (false);
	}

	// track distance
	void FixedUpdate () {
		if (clickedOn) {
			if (lastPlace == Vector3.zero) {
				lastPlace = startingPosition;
			}
			float distanceTraveledThisTime = Vector3.Distance (transform.position, lastPlace);
			lastPlace = transform.position;
			distanceTraveled += distanceTraveledThisTime;
		}
 	}

	protected override void OnMouseUp () {
		clickedOn = false;
		if (distanceTraveled > howFarToShake) {
			Debug.Log ("Shook enough: " + (int)distanceTraveled);
		}
		distanceTraveled = 0f;
		lastPlace = Vector3.zero;
		ResetPosition ();
	}

	public void SetMixing(Mixing toMix) {
		this.mixingBowl = toMix;
	}
}
