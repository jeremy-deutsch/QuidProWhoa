using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthColander : Draggable {

	public Mixing mixContainer;
	public float tolerance = 1f;
	public int enoughShakes = 6;

	private int shakes = 0;
	private float spillBuffer = 0f;
	private bool wentLeft = false;
	private Vector3 lastPlace = Vector3.zero;

	void FixedUpdate () {
		if (clickedOn) {
			if (lastPlace == Vector3.zero) {
				lastPlace = startingPosition;
			}
			if (Mathf.Abs (transform.position.x - mixContainer.transform.position.x) < tolerance) {

				if (Mathf.Abs (transform.position.x - mixContainer.transform.position.x) < Mathf.Epsilon) {
					// do nothing
				} else if (wentLeft && transform.position.x > lastPlace.x) {
					Debug.Log ("Shook right");
					shakes++;
					wentLeft = false;
					if (shakes == enoughShakes) {
						Debug.Log ("You shook it!");
						mixContainer.Action (Element.Earth);
					}
				} else if (!wentLeft && transform.position.x < lastPlace.x) {
					Debug.Log ("Shook left");
					shakes++;
					wentLeft = true;
					if (shakes == enoughShakes) {
						Debug.Log ("You shook it!");
						mixContainer.Action (Element.Earth);
					}
				}

			} else if (shakes > 0) {
				spillBuffer += Time.fixedDeltaTime;
				if (spillBuffer >= 1f) {
					spillBuffer = 0f;
					shakes--;
				}
			}
			lastPlace = transform.position;

		}
	}

	protected override void OnMouseUp () {
		clickedOn = false;
		shakes = 0;
		ResetPosition ();
	}
}
