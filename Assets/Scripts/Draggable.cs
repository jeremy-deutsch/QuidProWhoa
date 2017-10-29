using System.Collections;
using UnityEngine;

public abstract class Draggable : MonoBehaviour {
    
	protected bool clickedOn;
	protected Vector3 startingPosition;

	private Mixing bucket = null;
	private Vector3 offset;
	
	protected virtual void Start () {
		startingPosition = transform.position;
	}
	
	void OnMouseDown () {
		offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		clickedOn = true;
	}
	
	protected virtual void OnMouseUp () {
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

	// DroppedOn should not necessarily do anything
	protected virtual void DroppedOn (Mixing other) {}

	public void ResetPosition () {
		transform.position = startingPosition;
	}
}
