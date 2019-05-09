using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AgudezaVisual.Configuracion;

public class PartidaController : MonoBehaviour
{

	/// Constante del numero maximo de oportunidades por evaluacion
	private readonly int MAXIMA_OPORTUNIDAD = 5;
	/// Constante del numero maximo de errores por evaluacion
	private readonly int MAXIMA_ERROR = 3;
	/// Contador de oportunidades. Valor inicial 0
	private int contadorOportunidad;
	/// Contador de errores cometidos por evaluacion. Valor inicial 0 por evaluacion
	private int contadorErrores;


	public bool[] evaluacion_20_20;
	public bool[] evaluacion_25_20;
	public bool[] evaluacion_30_20;
	public bool[] evaluacion_40_20;
	public bool[] evaluacion_50_20;
	public bool[] evaluacion_70_20;
	public bool[] evaluacion_100_20;
	public bool[] evaluacion_200_20;
	public bool[] evaluacion_400_20;

	/// Optotipo que es la respuesta correcta de la oportunidad actual
	public OptotipoEnum respuestaActual;
	/// Distancia simulada de la oportunidad actual
	public DistanciaSimuladaEnum distanciaActual;
	/// Arreglo para llevar el control de los resultados de la evaluacion actual
	public bool[] evaluacionActual;

	public bool gameOver;

	/// <summary>
	/// Constructor: Inicializa evaluaciones
	/// </summary>
	public PartidaController ()
	{

		contadorOportunidad = 0;
		contadorErrores = 0;
		

		evaluacion_400_20 = new bool[5];

		distanciaActual = DistanciaSimuladaEnum.Escala_400_20;
		evaluacionActual = evaluacion_400_20;
		gameOver = false;

	}


	public bool EsRespuestaCorrecta (OptotipoEnum respuestaSeleccionada)
	{
		bool resultado = false;
		if (gameOver) {
			return false;
		}

		if (respuestaActual == respuestaSeleccionada) {
			Debug.Log ("RESPUESTA CORRECTA!!!!");
			resultado = true;
		} else {
			contadorErrores++;
			Debug.Log ("VUELVE A INTENTAR");
		}

		if (contadorErrores >= MAXIMA_ERROR) {
			gameOver = true;
		} else {
			ManejoDeRespuestas (resultado);
		}

		return resultado;
	}

	public void ManejoDeRespuestas (bool resultado)
	{
		evaluacionActual [contadorOportunidad] = resultado;

		if (++contadorOportunidad >= MAXIMA_OPORTUNIDAD) {
			SiguienteEvaluacion ();
		}
	}

	public void SiguienteEvaluacion() {
		contadorOportunidad = 0;
		contadorErrores = 0;

		switch (distanciaActual) {
		case DistanciaSimuladaEnum.Escala_400_20:
			evaluacion_200_20 = new bool[5];
			distanciaActual = DistanciaSimuladaEnum.Escala_200_20;
			evaluacionActual = evaluacion_200_20;
			break;
		case DistanciaSimuladaEnum.Escala_200_20:
			evaluacion_100_20 = new bool[5];
			distanciaActual = DistanciaSimuladaEnum.Escala_100_20;
			evaluacionActual = evaluacion_100_20;
			break;
		case DistanciaSimuladaEnum.Escala_100_20:
			evaluacion_70_20 = new bool[5];
			distanciaActual = DistanciaSimuladaEnum.Escala_70_20;
			evaluacionActual = evaluacion_70_20;
			break;
		case DistanciaSimuladaEnum.Escala_70_20:
			evaluacion_50_20 = new bool[5];
			distanciaActual = DistanciaSimuladaEnum.Escala_50_20;
			evaluacionActual = evaluacion_50_20;
			break;
		case DistanciaSimuladaEnum.Escala_50_20:
			evaluacion_40_20 = new bool[5];
			distanciaActual = DistanciaSimuladaEnum.Escala_40_20;
			evaluacionActual = evaluacion_40_20;
			break;
		case DistanciaSimuladaEnum.Escala_40_20:
			evaluacion_30_20 = new bool[5];
			distanciaActual = DistanciaSimuladaEnum.Escala_30_20;
			evaluacionActual = evaluacion_30_20;
			break;
		case DistanciaSimuladaEnum.Escala_30_20:
			evaluacion_25_20 = new bool[5];
			distanciaActual = DistanciaSimuladaEnum.Escala_25_20;
			evaluacionActual = evaluacion_25_20;
			break;
		case DistanciaSimuladaEnum.Escala_25_20:
			evaluacion_20_20 = new bool[5];
			distanciaActual = DistanciaSimuladaEnum.Escala_20_20;
			evaluacionActual = evaluacion_20_20;
			break;
		case DistanciaSimuladaEnum.Escala_20_20:
			gameOver = true;
			break;
		}
	}

}
