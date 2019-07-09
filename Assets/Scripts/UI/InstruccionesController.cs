using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AgudezaVisual.UI {
	
	public class InstruccionesController : MonoBehaviour {

		// Panels
		public GameObject panelJugador;

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

			SceneManager.LoadScene (escena);
		}

	}

}