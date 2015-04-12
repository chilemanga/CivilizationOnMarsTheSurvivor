using UnityEngine;
using System.Collections;

public class xplorer : MonoBehaviour {

	public GameObject InformativePanel;
	private int selectedButtonIndex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onXplorerClick(int buttonIndex){
		this.selectedButtonIndex = buttonIndex;
		InformativePanel.SetActive (true);
		InformativePanelBehaviour inf = InformativePanel.GetComponent<InformativePanelBehaviour> ();
		inf.descripcion.text = DataModelManager.instance.GetMissionDescription(buttonIndex);
	}
	public void ExitInformativa(){
		Debug.Log ("murio");
		InformativePanel.SetActive (false);
	}

	public void OnMissionConfirmed() {
		//TODO: Save which mission was selected
		Application.LoadLevel (2);
	}

}
