using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
	private Element desiredElement;
	private List<Buffs> desiredBuffs;

	// Use this for initialization
	void Start () {
		this.Enter ();
	}

	// Update is called once per frame
	void Update () {
	}

	public void Serve (Drink drink) {
		int stars = 1;

		if (drink.GetElement () == this.desiredElement) {
			stars += 2;
		}

		int prevCount = this.desiredBuffs.Count;
		foreach (Buffs buff in drink.GetBuffs ()) {
			this.desiredBuffs.Remove (buff);
		}

		if (this.desiredBuffs.Count < prevCount) {
			stars += 2;
		}
			
		switch (stars) {
		case 5:
			Debug.Log ("Super satisfied");
			break;
		case 3:
			Debug.Log ("Passable");
			break;
		case 1:
			Debug.Log ("Abysmal");
			break;
		default:
			Debug.Log ("Error");
			break;
		}

		this.Enter ();
	}

	public void Enter () {
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
}
