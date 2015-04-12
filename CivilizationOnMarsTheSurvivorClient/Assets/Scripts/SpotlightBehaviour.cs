using UnityEngine;
using System.Collections;

public class SpotlightBehaviour : MonoBehaviour {

	private Light _light;
	private Light light {
		get {
			if(_light == null) {
				_light = this.gameObject.GetComponent<Light>();
			}
			return _light;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (light.isActiveAndEnabled && Input.GetKeyUp (KeyCode.F)) {
			light.enabled = false;
			return;
		}
		if (!light.isActiveAndEnabled && Input.GetKeyUp (KeyCode.F)) {
			light.enabled = true;
			return;
		}
	}
}
