using UnityEngine;
using System.Collections;

public class VetaAguaBehaviour : MonoBehaviour {

	public Veta Veta {
		get;
		set;
	}
	
	// Use this for initialization
	void Start () {
		
		Veta.Recurso = Recurso.Agua;
		
		Veta.Masa = 15;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
