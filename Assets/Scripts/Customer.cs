using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour {
	public SpriteRenderer customerMugshot;
	public Text customerInfo;
	public Reviews reviews;
	public Sprite[] mugshotImages;

	private Element desiredElement;
	private List<string> desiredBuffs;
	private int mugshotIndicesIndex = -1;
	public int[] mugshotIndices;
	private int buffQueueIndex;
	private string[] buffQueue;

	void Awake() {
		mugshotIndices = new int[mugshotImages.Length];
		for (int i = 0; i < mugshotIndices.Length; i++) {
			mugshotIndices [i] = i;
		}
		Utils.Shuffle<int> (mugshotIndices);
		// use a queue of 2 of every buff, so that the demands are relatively even
		buffQueue = new string[(System.Enum.GetValues (typeof(Buffs)).Length) * 2];
		for (int i = 0; i < System.Enum.GetValues (typeof(Buffs)).Length; i++) {
			buffQueue [2 * i] = ((Buffs)i).ToString ();
			buffQueue [(2 * i) + 1] = ((Buffs)i).ToString ();
		}
		buffQueueIndex = 0;
		Utils.Shuffle<string> (buffQueue);
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
		foreach (string buff in drink.GetAndClearBuffs ()) {
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

		desiredBuffs = new List<string> ();
		for (int i = 0; i < 2; i++) {
			desiredBuffs.Add (buffQueue[buffQueueIndex]);
			buffQueueIndex++;
			if (buffQueueIndex >= buffQueue.Length) {
				buffQueueIndex = 0;
				Utils.Shuffle<string> (buffQueue);
			}
		}

		foreach (string buff in desiredBuffs) { 
			info += "\n " + buff;
		}
		customerInfo.text = info;
	}
}
