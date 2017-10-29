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

	public void Mix() {
		Element element = Element.Air;
		this.Mix (element);
	}

	public void Mix(Element element) {
		Mixing mix = this.GetComponent<Mixing> ();
		List<IngredientData> ingredients = mix.GetIngredients ();
		Debug.Log ("You have been served:");
		foreach (IngredientData ingredient in ingredients) {
			Debug.Log (ingredient.name);
			Debug.Log (ingredient.buff);
		}
		mix.ClearIngredients ();
	}
}
