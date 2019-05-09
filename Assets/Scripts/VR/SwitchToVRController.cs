using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SwitchToVRController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (SwitchToVR ());
	}
	
	IEnumerator SwitchToVR(){
		string desiredDevice = "cardboard";

		if (string.Compare (XRSettings.loadedDeviceName, desiredDevice, true) != 0) {
			XRSettings.LoadDeviceByName (desiredDevice);
			yield return null;
		}

		XRSettings.enabled = true;
	}
}
