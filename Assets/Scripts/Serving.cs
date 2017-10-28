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
		Debug.Log ("You have been served!");
		Debug.Log (this.GetComponent<Mixing> ().GetIngredients ());
	}
}
