namespace AgudezaVisual.VR
{
	

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[RequireComponent (typeof(Collider))]
	public class OptotipoController : MonoBehaviour
	{
		/// Listens to controller's input
		private InputController inputController;
		/// Indicates if the object is being gazed
		private bool gazedAt;


		public Material inactiveMaterial;
		public Material gazedAtMaterial;

		Renderer render;


		// Use this for initialization
		void Start ()
		{
			inputController = new InputController ();
			render = GetComponent<Renderer> ();

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
		/// <returns><c>true</c>, if answer was checked, <c>false</c> otherwise.</returns>
		public void CheckAnswer ()
		{
			Debug.Log ("===== checkAnswer =====");
			Debug.Log (render.material.name);
			Material material = Resources.Load ("Materials/e_snellen", typeof(Material)) as Material;
			render.material = material;
		}

	}
}