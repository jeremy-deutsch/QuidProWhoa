using System.Collections;
using UnityEngine;

public class Draggable : MonoBehaviour {
    private bool clickedOn;
	private Mixing chosen = null;
	private Vector3 startingPosition;
	
	void Start () {
		startingPosition = transform.position;
	}
	
	void Update () {
		if (clickedOn) {
			Dragging ();
        }
	}
	
	void OnMouseDown () {
		clickedOn = true;
	}
	
	void OnMouseUp () {
		clickedOn = false;
		transform.position = startingPosition;

		if (chosen == null) {
			return;
		}

		chosen.Drop (this.GetComponent<Naming> ());
	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

    void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Bucket")) {
			chosen = other.gameObject.GetComponent<Mixing>();
		}
    }

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Bucket")) {
			chosen = null;
		}
	}
}
