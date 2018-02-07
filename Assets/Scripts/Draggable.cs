using System.Collections;
using UnityEngine;

public abstract class Draggable : MonoBehaviour {
    
	protected bool clickedOn = false;
	protected bool mouseIsOver = false;
	protected Vector3 startingPosition;

	private static bool draggingSomething = false;

	private Mixing bucket = null;
	private Vector3 offset;
	private Vector3 normalSize;

	private Vector3 normalGobletSize;
	
	protected virtual void Start () {
		startingPosition = transform.position;
		normalSize = transform.localScale;
	}

	void OnMouseEnter () {
		if (!clickedOn && !draggingSomething) {
			transform.localScale = normalSize * 1.2f;
			mouseIsOver = true;
			HoverBegin ();
		}
	}

	// Called when the mouse begins hovering without dragging the object
	protected virtual void HoverBegin () {}

	void OnMouseExit () {
		if (!clickedOn) {
			transform.localScale = normalSize;
			mouseIsOver = false;
			HoverEnd ();
		}
	}

	// Called when the mouse moves away or begins dragging the object
	protected virtual void HoverEnd () {}

	void OnMouseDown () {
		offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.localScale = normalSize * 0.9f;
		clickedOn = true;
		draggingSomething = true;
		HoverEnd ();
	}

	protected virtual void OnMouseUp () {
		clickedOn = false;
		draggingSomething = false;
		if (bucket == null) {
			ResetPosition ();
		} else {
			// bucket.Drop (this.GetComponent<Naming> ());
			DroppedOn (bucket);
		}

	}

	void OnMouseDrag () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
		
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

    void OnTriggerEnter2D (Collider2D other) {
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
		transform.localScale = normalSize;
		draggingSomething = false;
	}
}
