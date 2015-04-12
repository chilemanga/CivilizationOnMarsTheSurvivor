using UnityEngine;
using System.Collections;

public class IntroSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	private float timer;
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= 21) {
			OnSaltarIntroClick();
		}
	}

	public void OnSaltarIntroClick() {
		Debug.Log ("skip pressed!");
		Application.LoadLevel (1); // menu principal
	}
}
