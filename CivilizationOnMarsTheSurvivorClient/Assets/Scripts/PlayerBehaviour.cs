using System;
using UnityEngine;
using UnityEngine.UI;
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

	public Text textHierro;
	public Text textAgua;
	public Text textSilicio;
	public Text textCalcio;
	public Text textMagnesio;
	private float nivelOxigeno = 100;
	public float speedNivelOxigeno = 1;

	// Use this for initialization
	void Start () {
	
		mochila = new List<Medidor> ();

		Mision = new Mision ();

	}
	
	// Update is called once per frame
	void Update () {

		nivelOxigeno -= speedNivelOxigeno * Time.deltaTime;

		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.LoadLevel(1); // Mission selection
		}


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

		//bool destroy = false;

		//if (collision.gameObject ) {
		Veta veta = collision.gameObject.GetComponent<Veta>();

		//VetaHierroBehaviour behaviourH = collision.gameObject.GetComponent<VetaHierroBehaviour>();
		if (veta != null) {

			AddVetaToMochila (veta);
			AddVetaToMision (veta);

			Medidor medidor = mochila.Single (m => m.Recurso == veta.Recurso);

			if (veta is VetaHierroBehaviour) {

				textHierro.text = String.Format ("{0} Kgs", medidor.MasaActual.ToString());	

			}else if (veta is VetaAguaBehaviour)
			{
				textAgua.text = String.Format ("{0} Lts", medidor.MasaActual.ToString());	
			}
			else if (veta is VetaSilicioBehaviour)
			{
				textSilicio.text = String.Format ("{0} Kgs", medidor.MasaActual.ToString());	
			}
			else if (veta is VetaCalcioBehaviour)
			{
				textCalcio.text = String.Format ("{0} Kgs", medidor.MasaActual.ToString());	
			}
			else if (veta is VetaMagnesioBehaviour)
			{
				textMagnesio.text = String.Format ("{0} Kgs", medidor.MasaActual.ToString());	
			}
		
			Debug.Log (String.Format ("Se agregaron {0} Kg de hierro a la mochila! Hierro en la mochila: {1}/{2} Kg", 
			                          veta.Masa.ToString (), 
			                          medidor.MasaActual.ToString (),
			                          medidor.MasaMaxima.ToString ()));
			
			Destroy (collision.gameObject);
		}

		if (Mision.EstaCumplida) {

			Debug.Log ("Mision cumplida!");

		}

	}

	private void AddVetaToMochila(Veta veta) {

		Medidor medidorHierro = mochila.SingleOrDefault (m => m.Recurso == veta.Recurso);

		if (medidorHierro == null) {

			medidorHierro = new Medidor() { MasaMaxima = 100, MasaActual = veta.Masa, Recurso = veta.Recurso };

			mochila.Add(medidorHierro);

		}
		else {

			medidorHierro.MasaActual += veta.Masa;

			if (medidorHierro.MasaActual > medidorHierro.MasaMaxima) {

				medidorHierro.MasaActual = medidorHierro.MasaMaxima;

			}

		}

	}

	private void AddVetaToMision(Veta veta){

		IList<MetaRecurso> metasRecurso = Mision.Metas
													.Select (m => m as MetaRecurso)
													.Where (m => m.Recurso == veta.Recurso)
													.ToList ();

		foreach (var metaRecurso in metasRecurso) {

			metaRecurso.MasaActual += veta.Masa;

		}

	}

}
