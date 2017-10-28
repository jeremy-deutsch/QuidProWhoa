using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Serving : MonoBehaviour {
	public Button yourButton;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Serve);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Serve () {
		Mixing mix = this.GetComponent<Mixing> ();
		Debug.Log ("You have been served:");
		foreach (string ingredient in mix.GetIngredients()) {
			Debug.Log (ingredient);
		}
		mix.ClearIngredients ();
	}
}
