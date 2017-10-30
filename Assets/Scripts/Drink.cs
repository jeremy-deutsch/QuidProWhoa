using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour {
	public Customer customer;

	private Element element;
	private List<Buffs> buffs;

	void Awake () {
		buffs = new List<Buffs> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Mix(Element element, List<IngredientData> ingredients) {
		this.name = "";
		this.element = element;
		this.buffs = new List<Buffs> ();

		foreach (IngredientData ingredient in ingredients) {
			this.buffs.Add (ingredient.buff);
			this.name += " " + ingredient.name;
		}
		this.name += " Tonic";

		Debug.Log ("Customer has been served:");
		Debug.Log (this.name);
		foreach (Buffs buff in this.buffs) {
			Debug.Log (buff);
		}

		customer.Serve (this);
	}

	public List<Buffs> GetAndClearBuffs() {
		List<Buffs> result = this.buffs;
		//this.buffs = new List<Buffs> ();
		return result;
	}

	public Element GetElement() {
		return this.element;
	}
}
