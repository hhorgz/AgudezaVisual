using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador {

	public static Jugador jugador = new Jugador();
	public string nombre;
	public int edad;

	public string getNombre(){
		return nombre;
	}

	public int getEdad(){
		return edad;
	}

	public void imprimirAtributos(){
		Debug.Log("===== JUGADOR =====");
		Debug.Log("Nombre => " + nombre);
		Debug.Log("Edad => " + edad);
	}
	
}
