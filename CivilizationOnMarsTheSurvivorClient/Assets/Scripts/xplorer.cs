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
		//Debug.Log (string.Format ("hizo clic a {0} {1}", buttonIndex, "caca") );
		InformativePanel.SetActive (true);
		InformativePanelBehaviour inf = InformativePanel.GetComponent<InformativePanelBehaviour> ();
		inf.descripcion.text = DataModelManager.instance.GetMissionDescription(buttonIndex);
	}
	public void ExitInformativa(){
		Debug.Log ("murio");
		InformativePanel.SetActive (false);
	}
}
