using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfiguracionController : MonoBehaviour {

	public InputField inputNombre;
	public InputField inputEdad;

	public void setConfiguracionJugador(){
		Jugador.jugador.setDatos(
			inputNombre.text,
			int.Parse(inputEdad.text)
		);
	}
}
