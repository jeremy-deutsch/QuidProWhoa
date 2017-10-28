using System.Collections;
using UnityEngine;

public class Draggable : MonoBehaviour {
    private bool clickedOn;
	
	void Start () {
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
	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}
}
