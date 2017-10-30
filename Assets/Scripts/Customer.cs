﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour {
	public SpriteRenderer customerMugshot;
	public Text customerInfo;
	public Reviews reviews;
	public Sprite[] mugshotImages;

	private Element desiredElement;
	private List<Buffs> desiredBuffs;
	private int mugshotIndicesIndex = -1;
	public int[] mugshotIndices;

	void Awake() {
		mugshotIndices = new int[mugshotImages.Length];
		for (int i = 0; i < mugshotIndices.Length; i++) {
			mugshotIndices [i] = i;
		}
		Utils.Shuffle<int> (mugshotIndices);
	}

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
		foreach (Buffs buff in drink.GetAndClearBuffs ()) {
			this.desiredBuffs.Remove (buff);
		}

		if (this.desiredBuffs.Count < prevCount) {
			stars += 2;
		}

		reviews.WriteReview (stars);

		this.Enter ();
	}

	public void Enter () {
		mugshotIndicesIndex++;
		if (mugshotIndicesIndex > mugshotIndices.Length) {
			mugshotIndicesIndex = 0;
			Utils.Shuffle<int> (mugshotIndices);
		}
		customerMugshot.sprite = mugshotImages [mugshotIndices [mugshotIndicesIndex]];

		desiredElement = (Element)Random.Range(0, System.Enum.GetValues(typeof(Element)).Length);
		Debug.Log (desiredElement);

		string info = " " + desiredElement;

		desiredBuffs = new List<Buffs> ();
		for (int i = 0; i < 2; i++) {
			Buffs randomBuff = (Buffs)Random.Range (0, System.Enum.GetValues (typeof(Buffs)).Length);
			desiredBuffs.Add (randomBuff);
		}

		foreach (Buffs buff in desiredBuffs) {
			info += "\n " + buff;
		}
		customerInfo.text = info;
	}
}
