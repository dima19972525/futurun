using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {

	public void RestartPressed() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void ExitPressed() {
		SceneManager.LoadScene ("Main");
	}

	public void ResumePressed() {
		GetComponent<GameHelper> ().CanvasPause.SetActive (false);
		GameState.State = GameState.States.PLAY;
		Time.timeScale = 1.0f;
	}

	public void MusicPressed() {
		GameObject.FindObjectOfType<CanvasAudio> ().VolumeChange();
	}
}
