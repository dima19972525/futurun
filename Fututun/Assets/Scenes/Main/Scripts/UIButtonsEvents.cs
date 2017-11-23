using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsEvents : MonoBehaviour {

    public void StartPressed()
    {
		SceneManager.LoadScene ("Game");
    }

    public void ExitPressed()
    {
		Application.Quit ();
    }
}
