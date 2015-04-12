using UnityEngine;
using System.Collections;

public class xplorer : MonoBehaviour {

	public GameObject InformativePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onXplorerClick(int buttonIndex){
		Debug.Log (string.Format ("hizo clic a {0} {1}", buttonIndex, "caca") );

		switch(buttonIndex)
		{
		
		case 0: 
			Debug.Log("facil");
			break;
		case 1:
			Debug.Log("medio");
			break;
		case 2:
			Debug.Log("dificil");
			break;
		default:
			Debug.Log("nada");
			break;
		}
		InformativePanel.SetActive (true);
	}
	public void ExitInformativa(){
		Debug.Log ("murio");
		InformativePanel.SetActive (false);
	}
}
