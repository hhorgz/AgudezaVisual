using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador {

	public static Jugador jugador = new Jugador();
	public string nombre = "placeholder";
	public int edad = 0;
	public bool estado = false;

	public string getNombre(){
		return nombre;
	}

	public int getEdad(){
		return edad;
	}

	public void setDatos(string nombre, int edad){
		this.nombre = nombre;
		this.edad = edad;
		this.estado = true;
	}

	public void imprimirAtributos(){
		Debug.Log("===== JUGADOR =====");
		Debug.Log("Nombre => " + nombre);
		Debug.Log("Edad => " + edad);
	}
	
}
