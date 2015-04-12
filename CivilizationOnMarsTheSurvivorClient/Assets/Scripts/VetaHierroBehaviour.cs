using UnityEngine;
using System.Collections;

public class VetaHierroBehaviour : Veta {

	public int masaValue = 25;

	// Use this for initialization
	void Start () {
		Recurso = Recurso.Hierro;
		Masa = masaValue;
	}
}
