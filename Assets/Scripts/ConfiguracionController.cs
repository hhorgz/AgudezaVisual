using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfiguracionController : MonoBehaviour {

	public InputField inputNombre;
	public InputField inputEdad;

	public void setConfiguracionJugador(){
		Debug.Log(inputNombre.text);
		Debug.Log(inputEdad.text);
		Jugador.jugador.nombre = inputNombre.text;
		Jugador.jugador.edad = int.Parse(inputEdad.text);
	}
}
