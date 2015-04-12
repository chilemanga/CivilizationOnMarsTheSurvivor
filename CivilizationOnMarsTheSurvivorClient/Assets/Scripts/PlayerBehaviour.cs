using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class PlayerBehaviour : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;

	private IList<Medidor> mochila;
	
	public Mision Mision {
		get;
		set;
	}

	// Use this for initialization
	void Start () {
	
		mochila = new List<Medidor> ();

		Mision = new Mision ();

	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			Debug.Log("adsfadsfad!!");

		}
		*/

		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}


	}

	public void OnCollisionEnter(Collision collision){

		Debug.Log (String.Format("collision.gameObject.tag: {0} gameObject.tag: {1}", collision.gameObject.tag, gameObject.tag));

		bool destroy = false;

		if (collision.gameObject.tag == "vetaHierro") {

			VetaHierroBehaviour behaviour = collision.gameObject.GetComponent<VetaHierroBehaviour>();

			AddVetaHierroToMochila(behaviour);

			Medidor medidorHierro = mochila.Single(m => m.Recurso == Recurso.Hierro);

			Debug.Log (String.Format ("Se agregaron {0} Kg de hierro a la mochila! Hierro en la mochila: {1}/{2} Kg", 
			                          behaviour.Veta.Masa.ToString(), 
			                          medidorHierro.MasaActual.ToString(),
			                          medidorHierro.MasaMaxima.ToString()));

			AddVetaHierroToMision(behaviour.Veta);

			if (Mision.EstaCumplida) {

				Debug.Log ("Mision cumplida!");

			}

			destroy = true;

		}

		if (collision.gameObject.tag == "vetaAgua") {

			//AddVetaAguaToMochila(collision.gameObject.GetComponent<VetaAguaBehaviour>());
			
			destroy = true;
			
		}

		if (destroy) {

			Destroy (collision.gameObject);

		}

	}

	private void AddVetaHierroToMochila(VetaHierroBehaviour vetaHierroBehaviour) {

		Veta vetaHierro = vetaHierroBehaviour.Veta;

		Medidor medidorHierro = mochila.SingleOrDefault (m => m.Recurso == vetaHierro.Recurso);

		if (medidorHierro == null) {

			medidorHierro = new Medidor() { MasaMaxima = 100, MasaActual = vetaHierro.Masa, Recurso = Recurso.Hierro };

			mochila.Add(medidorHierro);

		}
		else {

			medidorHierro.MasaActual += vetaHierro.Masa;

			if (medidorHierro.MasaActual > medidorHierro.MasaMaxima) {

				medidorHierro.MasaActual = medidorHierro.MasaMaxima;

			}

		}

	}

	private void AddVetaHierroToMision(Veta vetaHierro){

		IList<MetaRecurso> metasRecursoHierro = Mision.Metas
													.Select (m => m as MetaRecurso)
													.Where (m => m.Recurso == Recurso.Hierro)
													.ToList ();

		foreach (var metaRecurso in metasRecursoHierro) {

			metaRecurso.MasaActual += vetaHierro.Masa;

		}

	}

}
