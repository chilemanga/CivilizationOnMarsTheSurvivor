using System;
using UnityEngine;

public class Veta : MonoBehaviour {
	public int masaValue = 25;

	public Recurso Recurso {
		get;
		set;
	}

	public int Masa {
		get;
		set;
	}

	// Use this for initialization
	public void Start () {
		Masa = masaValue;
	}

}
