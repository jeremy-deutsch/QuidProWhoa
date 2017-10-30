using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthColander : Draggable {

	public Mixing mixContainer;
	public float tolerance = 1f;
	public int enoughShakes = 10;
	public float decayRate = 3f;

	private int shakes = 0;
	private float spillBuffer = 0f;
	private bool wentLeft = false;
	private Vector3 lastPlace = Vector3.zero;
	private bool shookEnough = false;

	void FixedUpdate () {
		if (clickedOn && !shookEnough) {
			if (lastPlace == Vector3.zero) {
				lastPlace = startingPosition;
			}
			if (Mathf.Abs (transform.position.x - mixContainer.transform.position.x) < tolerance) {

				if (Mathf.Abs (transform.position.x - mixContainer.transform.position.x) < Mathf.Epsilon) {
					// do nothing
				} else if (wentLeft && transform.position.x > lastPlace.x) {
					shakes++;
					wentLeft = false;
					if (shakes == enoughShakes) {
						Debug.Log ("You shook it!");
						mixContainer.Action (Element.Earth);
						shookEnough = true;
					}
				} else if (!wentLeft && transform.position.x < lastPlace.x) {
					shakes++;
					wentLeft = true;
					if (shakes == enoughShakes) {
						Debug.Log ("You shook it!");
						mixContainer.Action (Element.Earth);
						shookEnough = true;
					}
				}

			} else if (shakes > 0) {
				spillBuffer += Time.fixedDeltaTime * decayRate;
				if (spillBuffer >= 1f) {
					spillBuffer = 0f;
					shakes--;
				}
			}
			lastPlace = transform.position;

		}
	}

	protected override void OnMouseUp () {
		if (shookEnough) {
			this.gameObject.SetActive (false);
			mixContainer.EnableOnMix (this.gameObject);
		}
		shookEnough = false;
		clickedOn = false;
		shakes = 0;
		ResetPosition ();
	}
}
