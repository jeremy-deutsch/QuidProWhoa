using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreaking : MonoBehaviour {

	public GameObject draggingIce;
	public Sprite[] breakingIce;

	private int counter = 0;

	void Awake() {
		this.gameObject.SetActive (false);
	}

	void OnMouseDown() {

		counter++;
		Debug.Log ("hit " + counter);

		if(counter < breakingIce.Length) {
			GetComponent <SpriteRenderer>().sprite = breakingIce [counter];// Resources.Load<Sprite>("ice" + counter);
		} else if (counter >= 5) {
			Debug.Log ("Added Ice");
			counter = 0;
			// TODO: actually add ice
			draggingIce.GetComponent <IceDragger>().ResetPosition ();
			draggingIce.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

}
