using System.IO;
using UnityEngine;

[System.Serializable]
public class IngredientData {
	private static IngredientData[] allIngredients;
	private static int counter = -1;

	public string name;
	public Buffs buff;

	public static IngredientData GetRandomIngredient() {
		if (allIngredients == null) {
			allIngredients = AllIngredients.GetAllIngredients ();
		}
		counter = (counter + 1) % 2;

		return allIngredients [counter];
	}
}

[System.Serializable]
public class AllIngredients {
	public IngredientData[] ingredients;

	public static IngredientData[] GetAllIngredients() {
		string dataAsJson = File.ReadAllText ("Assets/JSON/ingredients.json"); 
		AllIngredients ret = JsonUtility.FromJson<AllIngredients> (dataAsJson);
		Debug.Log (ret.ingredients[1].name);
		return ret.ingredients;
	}
}
