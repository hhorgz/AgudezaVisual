using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertenciaController : MonoBehaviour {
	public GameObject panelAdvertencia;
	public GameObject panelFadeout;
	// Use this for initialization
	void Start () {
		panelFadeout.SetActive (false);
		panelAdvertencia.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (panelAdvertencia.activeSelf) {
			panelFadeout.SetActive (true);
		}
	}

	public void CloseWarning(){
		panelFadeout.SetActive (false);
		panelAdvertencia.SetActive (false);
	}
}
