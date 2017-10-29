using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixing : MonoBehaviour {
	private List<IngredientData> ingredients;
	

	// Use this for initialization
	void Start () {
		this.ClearIngredients ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Drop (IngredientData ingredient) {
		ingredients.Add (ingredient);
	}

	public List<IngredientData> GetIngredients () {
		return ingredients;
	}

	public void ClearIngredients () {
		ingredients = new List<IngredientData> ();
	}
}
