using System.IO;
using System.Collections;
using UnityEngine;

public class Ingredient : Draggable {
	private IngredientData data;
	public static IngredientSprites ingredientSprites;

	// Use this for initialization
	protected override void Start () {
		base.Start ();

		this.SetData ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetData() {
		data = IngredientData.GetRandomIngredient ();
		this.GetComponent<SpriteRenderer> ().sprite = ingredientSprites.GetSpriteFromName (data.name);
	}

	protected override void DroppedOn (Mixing other) {
		this.SetData ();
		this.ResetPosition ();
		other.Drop (this.data);
	}
}
