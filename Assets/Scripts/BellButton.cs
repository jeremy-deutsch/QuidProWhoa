using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellButton : MonoBehaviour {

	public Customer customer;
	public Drink drink;
	public Mixing mixing;

	void OnMouseUpAsButton () {
		Debug.Log ("clicked the button");
		mixing.Mix ();
	}
}
