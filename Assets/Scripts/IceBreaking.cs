using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreaking : MonoBehaviour {

	private int counter = 0;

	void OnMouseDown() {

		if(Input.GetMouseButtonDown(0)) {
			counter++;
			Debug.Log ("hit "+counter);
		}

		if(counter <= 3) {
			GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ice" + counter);
		}
	}

}
