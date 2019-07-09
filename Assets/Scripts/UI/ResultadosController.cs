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

		public Text labelNombre;
		public Text labelEdad;

		public Text resumen;

		
		// Use this for initialization
		void Start () {
			//Datos del jugador
			labelNombre.text = Jugador.jugador.Nombre;
			labelEdad.text = Jugador.jugador.Edad + " AÑOS";

			//Resultados
			ActualizarTextoResultados(label_400_20, "20/400", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_400_20));
//			label_400_20.text = "400/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_400_20)
//				+ " aciertos";
			ActualizarTextoResultados(label_200_20, "20/200", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_200_20));
//			label_200_20.text = "200/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_200_20)
//				+ " aciertos";
			ActualizarTextoResultados(label_100_20, "20/100", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_100_20));
//			label_100_20.text = "100/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_100_20)
//				+ " aciertos";
			ActualizarTextoResultados(label_70_20, "20/70", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_70_20));
//			label_70_20.text = "70/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_70_20)
//				+ " aciertos";
			ActualizarTextoResultados(label_50_20, "20/50", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_50_20));
//			label_50_20.text = "50/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_50_20)
//				+ " aciertos";
			ActualizarTextoResultados(label_40_20, "20/40", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_40_20));
//			label_40_20.text = "40/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_40_20)
//				+ " aciertos";
			ActualizarTextoResultados(label_30_20, "20/30", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_30_20));
//			label_30_20.text = "30/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_30_20)
//				+ " aciertos";
			ActualizarTextoResultados(label_25_20, "20/25", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_25_20));
//			label_25_20.text = "25/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_25_20)
//				+ " aciertos";
			ActualizarTextoResultados(label_20_20, "20/20", PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_20_20));
//			label_20_20.text = "20/20: " 
//				+ PartidaController.contarAciertos (Jugador.jugador.partida.evaluacion_20_20)
//				+ " aciertos";

			resumen.text = "RESUMEN: " + Jugador.jugador.partida.resumen;

			ActualizarAnchoCelda ();
		}
		
		private void ActualizarTextoResultados(Text etiqueta, string distancia, int aciertos) {
			etiqueta.text = distancia + ": " + aciertos + " aciertos";
			if (aciertos > 0) {
				etiqueta.color = Color.red;
			}
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