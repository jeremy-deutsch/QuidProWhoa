using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixing : MonoBehaviour {
	private List<string> ingredients;
	

	// Use this for initialization
	void Start () {
		ingredients = new List<string> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Drop (Naming ingredient) {
		Debug.Log (ingredient.name);
		ingredients.Add (ingredient.name);
	}

	public List<string> GetIngredients () {
		return ingredients;
	}
}
