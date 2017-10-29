using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEngine;
using UnityEngine.UI;


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
				Shuffle<MelpReviewData> (oneStarReviews);
			}
			oneCounter = (oneCounter + 1) % oneStarReviews.Length;
			return oneStarReviews [oneCounter];
		} else if (stars == 3) {
			if (threeStarReviews == null) {
				threeStarReviews = AllReviews.GetAllReviews (3);
				Shuffle<MelpReviewData> (threeStarReviews);
			}
			threeCounter = (threeCounter + 1) % allReviews.Length;
			return threeStarReviews [threeCounter];
		} else if (stars == 5) {
			if (fiveStarReviews == null) {
				fiveStarReviews = AllReviews.GetAllReviews (5);
				Shuffle<MelpReviewData> (fiveStarReviews);
			}
			fiveCounter = (fiveCounter + 1) % allReviews.Length;
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
		string dataAsJson = File.ReadAllText ("Assets/JSON/reviews.json");
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

	private int totalStars;
	private int totalCustomers;
	private float averageRating;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
