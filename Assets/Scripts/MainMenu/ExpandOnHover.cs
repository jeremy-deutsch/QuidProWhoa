using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandOnHover : MonoBehaviour {

	private Vector3 normalSize;

	void Start () {
		normalSize = transform.localScale;
	}

	void OnMouseEnter () {
		transform.localScale = normalSize * 1.03f;
	}

	void OnMouseExit () {
		transform.localScale = normalSize;
	}

	void OnMouseDown () {
		transform.localScale = normalSize * 0.95f;
	}
}
