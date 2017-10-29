using System.IO;
using UnityEngine;

[System.Serializable]
public class MelpReviewData {
	private static MelpReviewData[] allReviews;
	private static int counter = -1;

	public string name;
	public Buffs buff;

	public static MelpReviewData GetRandomReview() {
		if (allReviews == null) {
			allReviews = AllReviews.GetAllReviews ();
		}
		counter = (counter + 1) % 2;

		return allReviews [counter];
	}
}

[System.Serializable]
public class AllReviews {
	public MelpReviewData[] reviews;

	public static MelpReviewData[] GetAllReviews() {
		string dataAsJson = File.ReadAllText ("Assets/JSON/reviews.json"); 
		AllReviews ret = JsonUtility.FromJson<AllReviews> (dataAsJson);
		Debug.Log (ret.reviews[1].name);
		return ret.reviews;
	}
}
