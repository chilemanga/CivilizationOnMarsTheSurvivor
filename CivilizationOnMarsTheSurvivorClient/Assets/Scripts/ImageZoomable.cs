using UnityEngine;
using System.Collections;

public class ImageZoomable : MonoBehaviour {

	private float timeElapsed;
	public MissionBriefingController missionController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		transform.localScale += Vector3.one * Time.deltaTime/missionController.timeToNextScene;

	}
}
