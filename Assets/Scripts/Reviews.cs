using System.Collections;
using System.Collections.Generic;

using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]
public class MelpReviewData {
	private static MelpReviewData[] allReviews;
	private static MelpReviewData[] oneStarReviews;
	private static MelpReviewData[] threeStarReviews;
	private static MelpReviewData[] fiveStarReviews;
	private static int oneCounter = -1;
	private static int threeCounter = -1;
	private static int fiveCounter = -1;

	public string description;


	private static void Shuffle<T> (T[] arr) {
		int n = arr.Length;
		while (n > 1) {
			n--;
			int k = (int)(Random.value * (n + 1));
			T value = arr [k];
			arr [k] = arr [n];
			arr [n] = value;
		}
	}

	public static MelpReviewData GetRandomReview(int stars) {

		if (stars == 1) {
			if (oneStarReviews == null) {
				oneStarReviews = AllReviews.GetAllReviews (1);
				Utils.Shuffle<MelpReviewData> (oneStarReviews);
			}
			oneCounter = (oneCounter + 1) % oneStarReviews.Length;
			return oneStarReviews [oneCounter];
		} else if (stars == 3) {
			if (threeStarReviews == null) {
				threeStarReviews = AllReviews.GetAllReviews (3);
				Utils.Shuffle<MelpReviewData> (threeStarReviews);
			}
			threeCounter = (threeCounter + 1) % threeStarReviews.Length;
			return threeStarReviews [threeCounter];
		} else if (stars == 5) {
			if (fiveStarReviews == null) {
				fiveStarReviews = AllReviews.GetAllReviews (5);
				Utils.Shuffle<MelpReviewData> (fiveStarReviews);
			}
			fiveCounter = (fiveCounter + 1) % fiveStarReviews.Length;
			return fiveStarReviews [fiveCounter];
		} else {
			return null;
		}
	}
}

[System.Serializable]
public class AllReviews {
	public MelpReviewData[] oneStarReviews;
	public MelpReviewData[] threeStarReviews;
	public MelpReviewData[] fiveStarReviews;

	public static MelpReviewData[] GetAllReviews(int stars) {
		TextAsset reviewJsonData = Resources.Load ("JSON/reviews") as TextAsset;
		string dataAsJson = reviewJsonData.text; //File.ReadAllText ("Assets/JSON/reviews.json");
		AllReviews ret = JsonUtility.FromJson<AllReviews> (dataAsJson);
		if (stars == 1) {
			return ret.oneStarReviews;
		} else if (stars == 3) {
			return ret.threeStarReviews;
		} else if (stars == 5) {
			return ret.fiveStarReviews;
		} else {
			return null;
		}
	}
}


public class Reviews : MonoBehaviour {
	public Image starRating;
	public Text melpText;

	private int totalStars;
	private int totalCustomers;
	private float averageRating;

	// Use this for initialization
	void Start () {
		starRating.fillAmount = (float) 3.0 / 5;

		this.starRating.type = Image.Type.Filled;
		this.starRating.fillMethod = Image.FillMethod.Horizontal;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenu");
		}
	}

	public void WriteReview (int stars) {
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

		totalCustomers++;
		totalStars += stars;
		averageRating = (float) totalStars / (totalCustomers * 5.0f);
		starRating.fillAmount = averageRating;
		Debug.Log (totalStars);
		Debug.Log (totalCustomers);

		string desc = MelpReviewData.GetRandomReview (stars).description;
		Debug.Log ("Review: " + desc);
		string newMelpText = "";
		for (int i = 0; i < stars; i++) {
			newMelpText += "\u2605";
		}
		newMelpText += "\n" + desc;
		melpText.text = newMelpText;
	}
}
