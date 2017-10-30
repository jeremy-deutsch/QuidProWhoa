using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {

	public static void Shuffle<T> (T[] arr) {
		int n = arr.Length;
		while (n > 1) {
			n--;
			int k = (int)(Random.value * (n + 1));
			T value = arr [k];
			arr [k] = arr [n];
			arr [n] = value;
		}
	}
}
