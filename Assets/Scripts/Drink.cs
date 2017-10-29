using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour {
	private Element element;
	private List<Buffs> buffs;

	public Drink(string name, Element element, List<Buffs> buffs) {
		this.name = name;
		this.element = element;
		this.buffs = buffs;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
