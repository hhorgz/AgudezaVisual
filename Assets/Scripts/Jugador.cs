using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AgudezaVisual.Configuracion;

public class Jugador
{

	public static Jugador jugador = new Jugador ();

	public PartidaController partida = new PartidaController ();

	private string _nombre;
	private int _edad;

	public Jugador () {
		_nombre = "";
		_edad = 0;
	}

	public string Nombre {
		get { return _nombre; }
	}

	public int Edad {
		get{ return _edad; }
	}

	public DificultadEnumerator Dificultad {
		get {
			if (_edad < 5) { 
				return DificultadEnumerator.OPTOTIPOS_LEIA;
			} else {
				return DificultadEnumerator.OPTOTIPOS_SNELLEN;
			}
		}
	}

	public bool IsEmpty {
		get {
			if (string.IsNullOrEmpty (Nombre) || Edad == 0) {
				return true;
			} else {
				return false;
			}
		}
	}

	public bool setDatos (string nombre, int edad)
	{
		if (string.IsNullOrEmpty (nombre) || edad <= 0) {
			return false;
		} else {
			_nombre = nombre.ToUpper ();
			_edad = edad;
			return true;
		}
	}

	public override string ToString ()
	{
		return string.Format ("[Jugador: Nombre={0}, Edad={1}, IsEmpty={2}, Dificultad={3}]", Nombre, Edad, IsEmpty, Dificultad);
	}
}
