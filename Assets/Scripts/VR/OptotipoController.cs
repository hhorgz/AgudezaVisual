using AgudezaVisual.Configuracion;

namespace AgudezaVisual.VR
{
	
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[RequireComponent (typeof(Collider))]
	public class OptotipoController : MonoBehaviour
	{
		/// Constante del nombre de la escena de resultados
		private readonly string NOMBRE_ESCENA_RESULTADOS = "resultados";
		
		/// Listens to controller's input
		private InputController inputController;
		/// Indicates if the object is being gazed
		private bool gazedAt;
		private GameObject optotipoFactory;
		/// Sonido de respuesta correcta
		private AudioClip audioClipRespuestaCorrecta;
		/// Sonido de respuesta incorrecta
		private AudioClip audioClipRespuestaEquivocada;
		// Objeto de tipo AudioSource para reproducir el sonido
		AudioSource audioSource;


		/// Indicates the optotype value being held by the GameObject
		public OptotipoEnum optotypeValue;
		public Material inactiveMaterial;
		public Material gazedAtMaterial;

		Renderer render;


		// Use this for initialization
		void Start ()
		{
			inputController = new InputController ();
			render = GetComponent<Renderer> ();
			audioSource = GetComponent<AudioSource> ();
			optotipoFactory = GameObject.Find ("OptotipoFactory");

			audioClipRespuestaCorrecta = Resources.Load ("Sounds/respuesta_correcta", typeof(AudioClip)) as AudioClip;
			audioClipRespuestaEquivocada = Resources.Load ("Sounds/respuesta_incorrecta", typeof(AudioClip)) as AudioClip;
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (this.gazedAt && inputController.IsActionButtonPressed) {
				// Check if the optotype selected is the correct one
				CheckAnswer ();
			}
		}

		/**
		 * It defines the behavior of an object when this is gazed or not.
		 * - If gazedAt == true the object's material will be switched to gazedAtMaterial
		 * - If gazedAt == false the object's material will be switched to inactiveMaterial
		 */
		public void SetGazedAt (bool gazedAt)
		{
			this.gazedAt = gazedAt;
			if (inactiveMaterial != null && gazedAtMaterial != null) {
				render.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
				return;
			}
		}

		/// <summary>
		/// Checks the answer.
		/// </summary>
		public void CheckAnswer ()
		{
			// Verify that the game still hasn't over
			if (Jugador.jugador.partida.gameOver) {
				Debug.LogWarning ("===== GAME OVER =====");
				SceneManager.LoadScene (NOMBRE_ESCENA_RESULTADOS);

			} else {
				// If the game isn't over, verify the answer choosen
				bool EsRespuestaCorrecta = Jugador.jugador.partida.EsRespuestaCorrecta (optotypeValue);

				// Sonido a reproducir en base a la respuesta
				PlayAnswerAudioClip (EsRespuestaCorrecta);

				// If the game is over -> Show results scene
				if (Jugador.jugador.partida.gameOver) {
					SceneManager.LoadScene (NOMBRE_ESCENA_RESULTADOS);
				}
				// Else -> Generate new optotypes set
				else {
					if (optotipoFactory != null) {
						OptotipoFactory factory = optotipoFactory.GetComponent<OptotipoFactory> ();
						factory.GenerarNuevasOpciones ();
					} else {
						Debug.LogError ("No se pudo obtener OptotipoFactory");
					}
				}
			}

		}

		public void PlayAnswerAudioClip (bool isCorrect)
		{
			if (isCorrect) {
				audioSource.PlayOneShot (audioClipRespuestaCorrecta);
			} else {
				audioSource.PlayOneShot (audioClipRespuestaEquivocada);
			}
		}

	}
}