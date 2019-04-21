namespace AgudezaVisual.VR
{

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.XR;

	public class InputController : MonoBehaviour
	{
		/// <summary>
		/// Gets a value indicating whether a button has been pressed.
		/// </summary>
		/// <value><c>true</c> if a button has benn pressed; otherwise, <c>false</c>.</value>
		public bool IsActionButtonPressed {
			get {
				// 8BitDo: A
				if (Input.GetKeyUp (KeyCode.JoystickButton0)) {
					Debug.Log ("KeyUp: " + KeyCode.JoystickButton0.ToString ());
					return true;
				}
			// 8BitDo: B
			else if (Input.GetKeyUp (KeyCode.JoystickButton1)) {
					Debug.Log ("KeyUp: " + KeyCode.JoystickButton1.ToString ());
					return true;
				}

			// 8BitDo: X
			else if (Input.GetKeyUp (KeyCode.JoystickButton2)) {
					Debug.Log ("KeyUp: " + KeyCode.JoystickButton2.ToString ());
					return true;
				}

			// 8BitDo: Y
			else if (Input.GetKeyUp (KeyCode.JoystickButton3)) {
					Debug.Log ("KeyUp: " + KeyCode.JoystickButton3.ToString ());
					return true;
				}


			// 8BitDo: Left Dpad
			else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
					Debug.Log ("KeyUp: " + KeyCode.LeftArrow.ToString ());
					return true;
				}

			// 8BitDo: Right Dpad
			else if (Input.GetKeyUp (KeyCode.RightArrow)) {
					Debug.Log ("KeyUp: " + KeyCode.RightArrow.ToString ());
					return true;
				}

				return false;
			}
		}
	}
}