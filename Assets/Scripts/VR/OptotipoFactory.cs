using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AgudezaVisual.Configuracion;

namespace AgudezaVisual.VR
{
	public class OptotipoFactory : MonoBehaviour
	{
		
		private OptotipoEnum[] optotipos;
		public List<GameObject> opciones;

		public void Start ()
		{
//			Renderer render = opcion1.GetComponent<Renderer> ();
//			Material material = Resources.Load ("Materials/e_snellen", typeof(Material)) as Material;
//			render.material = material;
//
//			OptotipoController controller = opcion1.GetComponent<OptotipoController> ();
//			controller.inactiveMaterial = material;
//			controller.gazedAtMaterial = Resources.Load ("Materials/e_snellen_seleccionado", typeof(Material)) as Material;
			DefinirOpciones ();
		}

		private void SetOpcionesVR ()
		{ 
			
		}

		/**
		 * Opcion que retorna un numero aleatorio asociado con el nombre del optotipo
		 */
		private OptotipoEnum ObtenerOptotipoAleatorio ()
		{
			int rangoInferior = -1;
			int rangoSuperior = -1;
			int optotipoAleatorio;
			Random random = new Random ();

			// Definir el rango de la funcion aleatorio dependiendo del tipo de optotipos
			if (Jugador.jugador.Dificultad == DificultadEnumerator.OPTOTIPOS_LEIA) {
				rangoInferior = (int)OptotipoEnum.cruz_leia;
				rangoSuperior = (int)OptotipoEnum.estrella_leia_seleccionado;
			} else if (Jugador.jugador.Dificultad == DificultadEnumerator.OPTOTIPOS_SNELLEN) {
				rangoInferior = (int)OptotipoEnum.c_snellen;
				rangoSuperior = (int)OptotipoEnum.z_snellen_seleccionado;
			}

			// Obtener numero aleatorio
			optotipoAleatorio = Random.Range (rangoInferior, rangoSuperior);

			// Si el numero no es par quiere decir que es un optotipo de tipo seleccionado
			if (optotipoAleatorio % 2 != 0) {
				optotipoAleatorio--;
			}
			return (OptotipoEnum)optotipoAleatorio;
		}


		/**
		 * Funcion que asigna de manera aleatoria los valores de las opciones que estaran disponibles
		 */
		public void DefinirOpciones ()
		{
			// Definir la cantidad de opciones en base a la dificultad
			if (Jugador.jugador.Dificultad == DificultadEnumerator.OPTOTIPOS_LEIA) {
				optotipos = new OptotipoEnum[4];
			} else if (Jugador.jugador.Dificultad == DificultadEnumerator.OPTOTIPOS_SNELLEN) {
				optotipos = new OptotipoEnum[5];
			}

			// Obtener un valor aleatorio  para cada opcion
			for (int i = 0; i < optotipos.Length; i++) {
				OptotipoEnum optotipoAleatorio = ObtenerOptotipoAleatorio ();

				// Verificar si la opcion aun no existe
				if (!YaExisteOpcion (optotipoAleatorio)) {
					optotipos [i] = optotipoAleatorio;
					AsignarMateriales (opciones[i], optotipoAleatorio);
				} else {
					// Si la funcion ya existe, se intentara nuevamente
					i--;
					continue;
				}
			}
		}

		/**
		 * Compara si el OptotipoEnum que recibe como parametro ya 
		 * existe dentro del arreglo optotipos
		 */
		public bool YaExisteOpcion (OptotipoEnum opcion)
		{
			for (int i = 0; i < optotipos.Length; i++) {
				if (optotipos [i] == opcion)
					return true;
			}
			return false;
		}

		/**
		 * Cargar los materiales asociados al  OptotipoEnum y asignarlos al controlador de la opcion
		 */
		public void AsignarMateriales (GameObject opcion, OptotipoEnum optotipo)
		{
			// Obtenemos el controlador y el rederizador
			OptotipoController controller = opcion.GetComponent<OptotipoController> ();
			Renderer render = opcion.GetComponent<Renderer> ();

			// Material cuando no esta siendo observado
			Material inactiveMaterial = Resources.Load ("Materials/" + optotipo, typeof(Material)) as Material;
			controller.inactiveMaterial = inactiveMaterial;
			render.material = inactiveMaterial;

			// Material cuando esta siendo observado
			Material gazedAtMaterial = Resources.Load ("Materials/" + optotipo + "_seleccionado", typeof(Material)) as Material;
			controller.gazedAtMaterial = gazedAtMaterial;
		}
	}
}