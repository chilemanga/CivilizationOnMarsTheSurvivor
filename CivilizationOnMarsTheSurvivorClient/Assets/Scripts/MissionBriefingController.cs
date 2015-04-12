using UnityEngine;
using System.Collections;

public class MissionBriefingController : MonoBehaviour {

	public UnityEngine.UI.Text countdownText;
	private float timeElapsed;
	public float timeToNextScene = 10f;
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		countdownText.text = Mathf.RoundToInt(timeToNextScene - timeElapsed).ToString();
		
		if( timeElapsed > timeToNextScene ) {
			GoToNextScene ();
		}
	}
	
	public void GoToNextScene ()
	{
		// To the game!
		Application.LoadLevel (3);
	}
}
