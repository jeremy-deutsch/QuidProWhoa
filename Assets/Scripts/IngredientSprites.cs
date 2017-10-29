using UnityEngine;

public class IngredientSprites : MonoBehaviour
{
	private Object[] sprites;

	void Awake() {
		sprites = Resources.LoadAll("IngredientSprites", typeof(Sprite));
		Ingredient.ingredientSprites = this;
	}

	void Start() {
	}

	public Sprite GetSpriteFromName(string name) {
		foreach (Sprite s in sprites) {
			if (s.name == name) {
				return s;
			}
		}

		return null;
	}
}
