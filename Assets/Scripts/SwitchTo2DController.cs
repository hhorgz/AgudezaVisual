using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SwitchTo2DController : MonoBehaviour {

	void Start () {
		StartCoroutine (SwitchTo2D ());
	}

	IEnumerator SwitchTo2D(){
		XRSettings.LoadDeviceByName ("");
		yield return null;
		ResetCameras ();
	}

	void ResetCameras() {
		for (int i = 0; i < Camera.allCameras.Length; i++) {
			Camera cam = Camera.allCameras [i];
			if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None) {
				cam.transform.localPosition = Vector3.zero;
				cam.transform.localRotation = Quaternion.identity;
			}
		}
	}
}
