using System.IO;
using System.Collections;
using UnityEngine;

public class Ingredient : Draggable {
	private IngredientData data;
	public static IngredientSprites ingredientSprites;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		data = IngredientData.GetRandomIngredient ();

		this.GetComponent<SpriteRenderer> ().sprite = ingredientSprites.GetSpriteFromName (data.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void DroppedOn (Mixing other) {
		this.ResetPosition ();
		other.Drop (this.GetComponent<Naming> ());
	}
}
