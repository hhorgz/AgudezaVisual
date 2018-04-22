using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour {

	public GameObject panelJugador;
	public Text lblNombre;
	public Text lblEdad;

	// Use this for initialization
	void Start () {
		if (Jugador.jugador.estado == false)
		{
			panelJugador.SetActive(false);
		}
		else
		{
			panelJugador.SetActive(true);
			this.lblNombre.text = Jugador.jugador.nombre;
			this.lblEdad.text = Jugador.jugador.edad + " años";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
