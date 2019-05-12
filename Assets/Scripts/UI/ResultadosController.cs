using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AgudezaVisual.UI {
	public class ResultadosController : MonoBehaviour {

		public Text label_400_20;
		public Text label_200_20;
		public Text label_100_20;
		public Text label_70_20;
		public Text label_50_20;
		public Text label_40_20;
		public Text label_30_20;
		public Text label_25_20;
		public Text label_20_20;
		public Text resumen;

		
		// Use this for initialization
		void Start () {
			label_400_20.text = "400/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_400_20)
				+ " aciertos";

			label_200_20.text = "200/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_200_20)
				+ " aciertos";

			label_100_20.text = "100/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_100_20)
				+ " aciertos";

			label_70_20.text = "70/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_70_20)
				+ " aciertos";

			label_50_20.text = "50/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_50_20)
				+ " aciertos";

			label_40_20.text = "40/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_40_20)
				+ " aciertos";

			label_30_20.text = "30/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_30_20)
				+ " aciertos";

			label_25_20.text = "25/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_25_20)
				+ " aciertos";

			label_20_20.text = "20/20: " 
				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_20_20)
				+ " aciertos";

			resumen.text = "RESUMEN: " + Jugador.jugador.partida.resumen;

			ActualizarAnchoCelda ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private void ActualizarAnchoCelda(){
			RectTransform rt = (RectTransform) GetComponent<RectTransform> ();
			GridLayoutGroup layout = (GridLayoutGroup) GetComponent<GridLayoutGroup> ();
			layout.cellSize = new Vector3 ((rt.rect.width - layout.spacing.x) / 2, (rt.rect.height - (layout.spacing.y * 4)) / 5);
		}

		public void CargarEscena(string escena){
			SceneManager.LoadScene (escena);
		}

		public void LimpiarJugador(){
			Jugador.jugador = new Jugador ();
		}

		public void GuardarScreenshot() {
			string miCaptura = "Resultado" 
				+ System.DateTime.Now.Hour 
				+ System.DateTime.Now.Minute 
				+ System.DateTime.Now.Second 
				+ ".png";
			ScreenCapture.CaptureScreenshot (miCaptura);
		}
	}
}