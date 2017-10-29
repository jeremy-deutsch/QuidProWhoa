using UnityEngine;

public class IngredientSprites : MonoBehaviour
{
	private Object[] sprites;

	void Start() {
		sprites = Resources.LoadAll("IngredientSprites", typeof(Sprite));

		foreach (Sprite s in sprites) {
			Debug.Log(s.name);
		}

		Ingredient.ingredientSprites = this;
	}

	public Sprite getSpriteFromName(string name) {
		foreach (Sprite s in sprites) {
			if (s.name == name) {
				return s;
			}
		}

		return null;
	}
}
