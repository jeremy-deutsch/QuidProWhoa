using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mixing : MonoBehaviour {
	private List<IngredientData> ingredients;
	private Element element;
	private bool finishedMixing = false;
	public Button yourButton;
	public Drink drink;

	private Queue <GameObject> objectsToEnableOnMix;

	// Use this for initialization
	void Start () {
		objectsToEnableOnMix = new Queue <GameObject> ();
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Mix);
		this.ClearIngredients ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Drop (IngredientData ingredient) {
		ingredients.Add (ingredient);
	}

	public void Action (Element element) {
		this.element = element;
		finishedMixing = true;
	}

	public List<IngredientData> GetIngredients () {
		return ingredients;
	}

	public void ClearIngredients () {
		ingredients = new List<IngredientData> ();
		finishedMixing = false;
	}

	public void EnableOnMix(GameObject obj) {
		objectsToEnableOnMix.Enqueue (obj);
	}

	public void Mix() {
		if (!finishedMixing) {
			Debug.Log ("Must perform action on mixing bowl first");
			return;
		}
		while (objectsToEnableOnMix.Count > 0) {
			objectsToEnableOnMix.Dequeue ().SetActive (true);
		}
		Debug.Log (this.element);
		Mixing mix = this.GetComponent<Mixing> ();
		List<IngredientData> ingredients = mix.GetIngredients ();
		drink.Mix(this.element, this.ingredients);
		ClearIngredients ();
	}
}
