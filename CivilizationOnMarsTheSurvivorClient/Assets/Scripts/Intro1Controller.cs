using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {

		TextIntro1.CrossFadeAlpha (0, 0, false);
	}

	private float timer;
	public float timeBegin;
	public float timeFinish;
	public Text TextIntro1;

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer >= timeBegin && timer < timeFinish) {
			
			TextIntro1.CrossFadeAlpha (1, 0.5f, false);

		}

		if (timer >= timeFinish) {

			TextIntro1.CrossFadeAlpha (0, 0.5f, false);

		}

	}
}
