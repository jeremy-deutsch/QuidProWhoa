using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour {
	private Element element;
	private List<Buffs> buffs;

	public Drink(Element element, List<IngredientData> ingredients) {
		this.name = "";
		this.element = element;
		this.buffs = new List<Buffs> ();

		foreach (IngredientData ingredient in ingredients) {
			this.buffs.Add (ingredient.buff);
			this.name += " " + ingredient.name;
		}
		this.name += " Tonic";
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
