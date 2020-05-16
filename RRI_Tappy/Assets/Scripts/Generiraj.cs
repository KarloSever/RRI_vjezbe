using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generiraj : MonoBehaviour {
	public GameObject stijene;
	int rezultat=0;
	void Start () {
		InvokeRepeating ("KreirajStijene", 1f, 1.5f);
	}
	void OnGUI(){
		GUI.color = Color.black;
		GUILayout.Label ("Rezultat: " + rezultat.ToString ());
	}

	void KreirajStijene () {
		Instantiate (stijene);
		rezultat++;
	}
}
