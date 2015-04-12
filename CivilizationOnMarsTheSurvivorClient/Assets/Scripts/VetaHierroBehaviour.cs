using UnityEngine;
using System.Collections;

public class VetaHierroBehaviour : Veta {


	// Use this for initialization
	void Start () {
		base.Start();
		Recurso = Recurso.Hierro;
	}
}
