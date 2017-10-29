using System.Collections;
using UnityEngine;

public abstract class Draggable : MonoBehaviour {
    
	private bool clickedOn;
	private Mixing bucket = null;
	private Vector3 startingPosition;
	private Vector3 offset;
	
	protected virtual void Start () {
		startingPosition = transform.position;
	}
	
	void Update () {

	}
	
	void OnMouseDown () {
		offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		clickedOn = true;
	}
	
	void OnMouseUp () {
		clickedOn = false;

		if (bucket == null) {
			ResetPosition ();
			return;
		}

		// bucket.Drop (this.GetComponent<Naming> ());
		DroppedOn (bucket);
	}

	void OnMouseDrag () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
		
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

    void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("triggered");
		if (other.CompareTag ("Bucket")) {
			bucket = other.gameObject.GetComponent<Mixing>();
		}
    }

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Bucket")) {
			bucket = null;
		}
	}

	protected bool isBeingDragged () {
		return clickedOn;
	}

	// DroppedOn should not necessarily do anything
	protected virtual void DroppedOn (Mixing other) {}

	protected void ResetPosition () {
		transform.position = startingPosition;
	}
}
