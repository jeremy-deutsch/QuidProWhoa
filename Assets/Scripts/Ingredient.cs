using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSprites {

	private Object[] sprites;

	public IngredientSprites() {
		sprites = Resources.LoadAll("IngredientSprites", typeof(Sprite));
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

[System.Serializable]
public class IngredientData {
	private static IngredientData[] allIngredients;
	private static int counter = -1;

	public string name;
	public string buff;

	public static IngredientData GetRandomIngredient() {
		if (allIngredients == null) {
			allIngredients = AllIngredients.GetAllIngredients ();
		}
		counter = (counter + 1) % allIngredients.Length;

		return allIngredients [counter];
	}
}

[System.Serializable]
public class AllIngredients {
	public IngredientData[] ingredients;

	public static IngredientData[] GetAllIngredients() {
		TextAsset ingredientJsonData = Resources.Load ("JSON/ingredients") as TextAsset;
		string dataAsJson = ingredientJsonData.text; //File.ReadAllText ("Assets/JSON/ingredients.json"); 
		AllIngredients ret = JsonUtility.FromJson<AllIngredients> (dataAsJson);
		return ret.ingredients;
	}
}

public class Ingredient : Draggable {
	
	public static IngredientSprites ingredientSprites;
	public Text ingredientNameText;
	public Text ingredientInfoText;
	public float turningFrequency = 6f;
	public float turningAllowance = 2f;

	public Sprite[] sprites; // set these in the prefab

	private IngredientData data;

	private Quaternion normalAngle;
	private bool turningRight = false;
	private float rotationTolerance = 0f;
	private float negativeTurningAllowance;
	private float turningFrequencyTimesTurningAllowance;

	private float spriteHeight;

	private SpriteRenderer spriteRenderer;
	private string originalSortingLayerName;



	// Use this for initialization
	protected override void Start () {
		base.Start ();

		if (ingredientSprites == null) {
			ingredientSprites = new IngredientSprites ();
		}

		spriteRenderer = this.GetComponent <SpriteRenderer> ();
		originalSortingLayerName = spriteRenderer.sortingLayerName;

		this.SetData ();
		normalAngle = transform.rotation;

		negativeTurningAllowance = turningAllowance * -1f;
		turningFrequencyTimesTurningAllowance = turningFrequency * turningAllowance;
	}
	
	// Update is called once per frame
	void Update () {
		if (clickedOn) {
			if (turningRight) {
				float toRotate = turningFrequencyTimesTurningAllowance * Time.deltaTime * -1f;
				transform.Rotate (new Vector3(0f, 0f, toRotate));
				rotationTolerance += toRotate;
				if (rotationTolerance <= negativeTurningAllowance) {
					turningRight = false;
				}
			} else {
				float toRotate = turningFrequencyTimesTurningAllowance * Time.deltaTime;
				transform.Rotate (new Vector3(0f, 0f, toRotate));
				rotationTolerance += toRotate;
				if (rotationTolerance >= turningAllowance) {
					turningRight = true;
				}
			}
			if (spriteRenderer.sortingLayerName == originalSortingLayerName) {
				spriteRenderer.sortingLayerName = "Interactables";
			}
		}
	}

	protected override void HoverBegin () {
		ingredientNameText.gameObject.SetActive (true);
		ingredientNameText.transform.position = transform.position + new Vector3 (0f, (spriteHeight / 2f) + 1f);
		ingredientNameText.text = data.name.ToUpper ();
		ingredientInfoText.gameObject.SetActive (true);
		ingredientInfoText.transform.position = transform.position - new Vector3 (0f, (spriteHeight / 2f) + 1f);
		ingredientInfoText.text = data.buff;
	}

	protected override void HoverEnd () {
		ingredientNameText.gameObject.SetActive (false);
		ingredientInfoText.gameObject.SetActive (false);
	}

	protected override void OnMouseUp () {
		transform.rotation = normalAngle;
		spriteRenderer.sortingLayerName = originalSortingLayerName;
		base.OnMouseUp ();
	}

	private void SetData () {
		data = IngredientData.GetRandomIngredient ();
		this.spriteRenderer.sprite = ingredientSprites.GetSpriteFromName (data.name);
		Vector3 newSize = spriteRenderer.sprite.bounds.size;
		GetComponent <BoxCollider2D> ().size = new Vector2 (newSize.x, newSize.y);
		spriteHeight = newSize.y;
	}

	protected override void DroppedOn (Mixing other) {
		other.Drop (this.data);
		this.SetData ();
		this.gameObject.SetActive (false);
		other.EnableOnMix (this.gameObject);
		this.ResetPosition ();
	}

	private Sprite GetSpriteFromName(string name) {
		foreach (Sprite s in sprites) {
			if (s.name == name) {
				return s;
			}
		}

		return null;
	}
}
