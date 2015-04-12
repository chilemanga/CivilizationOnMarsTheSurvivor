using UnityEngine;
using System.Collections;

public class VetaHierroBehaviour : MonoBehaviour {

	public Veta Veta {
		get;
		set;
	}

	// Use this for initialization
	void Start () {

		Veta = new Veta ();
	
		Veta.Recurso = Recurso.Hierro;

		Veta.Masa = 25;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
