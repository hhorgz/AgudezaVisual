using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador {
//	private string _nombre = null;
//	private int _edad = 0;
	private string _nombre = "dummy";
	private int _edad = 100;

	public static Jugador jugador = new Jugador();
	public string Nombre {
		get { return _nombre; }
	}
	public int Edad {
		get{ return _edad; }
	}
	public bool IsEmpty {
		get{
			if (string.IsNullOrEmpty (Nombre) || Edad == 0) {
				return true;
			} else {
				return false;
			}
		}
	}

	public bool setDatos(string nombre, int edad){
		if (string.IsNullOrEmpty (nombre) || edad <= 0) {
			return false;
		} else {
			_nombre = nombre.ToUpper();
			_edad = edad;
			return true;
		}
	}

	public override string ToString ()
	{
		return string.Format ("[Jugador: Nombre={0}, Edad={1}, IsEmpty={2}]", Nombre, Edad, IsEmpty);
	}
}
