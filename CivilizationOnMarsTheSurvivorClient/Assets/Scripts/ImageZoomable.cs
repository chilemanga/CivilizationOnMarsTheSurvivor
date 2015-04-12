using UnityEngine;
using System.Collections;

public class ImageZoomable : MonoBehaviour {

	private float timeElapsed;
	public float timeToGoNextScene = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		transform.localScale += Vector3.one * Time.deltaTime/timeToGoNextScene;

		if( timeElapsed > timeToGoNextScene ) {
			GoToNextScene ();
		}
	}

	static void GoToNextScene ()
	{
		// To the game!
		Application.LoadLevel (3);
	}
}
