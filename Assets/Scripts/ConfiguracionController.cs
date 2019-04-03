using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfiguracionController : MonoBehaviour {

	public GameObject panelAdvertencia;
	public Text mensajeAdvertencia;
	public InputField inputNombre;
	public InputField inputEdad;

	public void setConfiguracionJugador(){
		if (string.IsNullOrEmpty (inputNombre.text) ||
		    string.IsNullOrEmpty (inputEdad.text)) {
			//Lanzar advertencia
			Debug.LogWarning("The name must not be empty and the age must be higher than 0");
			actualizarMensajeAdvertencia ("El nombre no debe de estar vacío ni la edad debe ser menor a cero");
		} else {
			Jugador.jugador.setDatos (
				inputNombre.text,
				int.Parse (inputEdad.text)
			);
			actualizarMensajeAdvertencia ("Jugador configurado exitosamente");
		}

		panelAdvertencia.SetActive (true);
		// LOG DEBUG
		Debug.Log(Jugador.jugador.ToString ());
	}

	public void cambiarEscena(string escena){
		// LOG DEBUG
		Debug.Log(string.Format("Se intenta cargar la escena: {0}", escena));
		SceneManager.LoadScene (escena);
	}

	public void actualizarMensajeAdvertencia(string mensaje){
		mensajeAdvertencia.text = mensaje;
	}
}
