using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Funcion que permite la transicion entre escenas
	// Recibe como parametro el nombre de la escena a cargar
	public void cargarEscena (string escena) {
		Debug.Log(string.Format("Se intenta cargar la escena: {0}", escena));
		SceneManager.LoadScene(escena);

		Jugador.jugador.imprimirAtributos();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
