using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class HomeController : MonoBehaviour {

	// Panels
	public GameObject panelJugador;
	public GameObject panelAdvertencia;

	// Labels
	public Text lblNombre;
	public Text lblEdad;

	// Use this for initialization
	void Start () {
		if (Jugador.jugador.IsEmpty == true)
		{
			panelJugador.SetActive(false);
		}
		else
		{
			panelJugador.SetActive(true);
			this.lblNombre.text = Jugador.jugador.Nombre;
			this.lblEdad.text = Jugador.jugador.Edad + " años";
		}
	}

	/// Funcion que permite la transicion entre escenas
	/// Recibe como parametro el nombre de la escena a cargar
	public void cargarEscena (string escena) {
		// LOG DEBUG
		Debug.Log(string.Format("Se intenta cargar la escena: {0}", escena));
		Debug.Log ("===== DATOS JUGADOR =====");
		Debug.Log (Jugador.jugador.ToString ());

		if (escena.Equals ("evaluacion_vr")) {
			if (!Jugador.jugador.IsEmpty) {
//				StartCoroutine (SwtichToVR());
				SceneManager.LoadScene (escena);
			} else {
				// LOG DEBUG
				panelAdvertencia.SetActive(true);
				Debug.LogWarning ("The evaluation cannot be started without a player configuration");
			}
		} else {
			SceneManager.LoadScene (escena);
		}

	}

	IEnumerator SwtichToVR(){
		string desiredDevice = "cardboard";

		if (string.Compare (XRSettings.loadedDeviceName, desiredDevice, true) != 0) {
			XRSettings.LoadDeviceByName (desiredDevice);
			yield return null;
		}

		XRSettings.enabled = true;
	}
}
