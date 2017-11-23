using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasAudio : MonoBehaviour {

	public Sprite VolumeOn, VolumeOff;
	public Image VolumeImage;

	private static CanvasAudio singleton = null;
	private bool volume;

	void Awake() {
		if (singleton != null)
			Destroy (gameObject);
		else {
			singleton = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		SceneManager.activeSceneChanged += sceneChanged;
		int i = PlayerPrefs.GetInt ("Volume", 1);	
		if (i == 1) {
			VolumeImage.sprite = VolumeOn;
			volume = true;
		}
		else {
			VolumeImage.sprite = VolumeOff;
			DisableAudioSources ();
		}
		
	}

	public void VolumeChange() {
		if (VolumeImage.sprite == VolumeOff) {
			VolumeImage.sprite = VolumeOn;
			PlayerPrefs.SetInt ("Volume", 1);
			EnableAudioSources ();
		} else {
			VolumeImage.sprite = VolumeOff;
			PlayerPrefs.SetInt ("Volume", 0);
			DisableAudioSources ();
		}
	}

	private void DisableAudioSources() {
		AudioSource[] a = GameObject.FindObjectsOfType<AudioSource> ();
		foreach (var i in a)
			i.Stop();
		FindObjectOfType<AudioListener> ().enabled = false;
		volume = false;
	}

	private void EnableAudioSources() {
		AudioSource[] a = GameObject.FindObjectsOfType<AudioSource> ();
		foreach (var i in a) {
			if (i.GetComponent<AudioPlayer>())
				i.Play ();
		}
		FindObjectOfType<AudioListener> ().enabled = true;
		volume = true;
	}

	private void sceneChanged(Scene arg1, Scene arg2) {
		if (!volume)
			DisableAudioSources ();
	}
}
