using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float speed;

	// Update is called once per frame
	void Update () {

		Vector3 movement;

		if (rigidbody.position.x <= -7 || rigidbody.position.x >= 0) {
			speed = speed * -1;
		}

		//text1.material.color.a -= 0.01f;

		movement = new Vector3 (rigidbody.position.x + speed, 0.0f);

		rigidbody.MovePosition (movement);

	}
}
