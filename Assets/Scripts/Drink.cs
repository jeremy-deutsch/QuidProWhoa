using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour {
	public Customer customer;

	private Element element;
	private List<string> buffs;

	void Awake () {
		buffs = new List<string> ();
	}

	public void Mix(Element element, List<IngredientData> ingredients) {
		this.name = "";
		this.element = element;
		this.buffs = new List<string> ();

		foreach (IngredientData ingredient in ingredients) {
			this.buffs.Add (ingredient.buff);
			this.name += " " + ingredient.name;
		}
		this.name += " Tonic";

		Debug.Log ("Customer has been served:");
		Debug.Log (this.name);
		foreach (string buff in this.buffs) {
			Debug.Log (buff);
		}

		customer.Serve (this);
	}

	public List<string> GetAndClearBuffs() {
		List<string> result = this.buffs;
		//this.buffs = new List<Buffs> ();
		return result;
	}

	public Element GetElement() {
		return this.element;
	}
}
