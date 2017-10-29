using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
	private Element desiredElement;
	private List<Buffs> desiredBuffs;

	// Use this for initialization
	void Start () {
		desiredElement = (Element)Random.Range(0, System.Enum.GetValues(typeof(Element)).Length);
		Debug.Log (desiredElement);

		desiredBuffs = new List<Buffs> ();
		for (int i = 0; i < 2; i++) {
			Buffs randomBuff = (Buffs)Random.Range (0, System.Enum.GetValues (typeof(Buffs)).Length);
			desiredBuffs.Add (randomBuff);
		}

		foreach (Buffs buff in desiredBuffs) {
			Debug.Log (buff);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Serve (Drink drink) {
	}
}
