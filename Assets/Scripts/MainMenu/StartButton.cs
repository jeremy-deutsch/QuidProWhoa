using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	void OnMouseUpAsButton() {
		SceneManager.LoadScene ("Bar");
	}
}
