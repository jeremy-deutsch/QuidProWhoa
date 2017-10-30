using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreaking : MonoBehaviour {

	public IceDragger draggingIce;
	public Sprite[] breakingIce;
	public Mixing mixingBowl;

	private int counter = 0;

	void Awake() {
		this.gameObject.SetActive (false);
	}

	void OnEnable () {
		GetComponent <SpriteRenderer>().sprite = breakingIce [0];
	}

	void OnMouseDown() {

		counter++;
		Debug.Log ("hit " + counter);

		if(counter < breakingIce.Length) {
			GetComponent <SpriteRenderer>().sprite = breakingIce [counter];
		} else if (counter >= 5) {
			Debug.Log ("Added Ice");
			mixingBowl.Action (Element.Ice);
			counter = 0;
			this.gameObject.SetActive (false);
		}
	}

}
