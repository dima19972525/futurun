using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	private static AudioPlayer singleton = null; 
	// Use this for initialization
	void Awake() {
		if (singleton != null)
			Destroy (gameObject);
		else {
			singleton = this;
			DontDestroyOnLoad (gameObject);
		}
	}
}
