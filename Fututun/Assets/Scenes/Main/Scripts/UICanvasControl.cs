using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasControl : MonoBehaviour {

	public Button[] Buttons;

	public Sprite Red, Blue;
	private short selected;

	void Start()
	{
		selected = 0;
		Buttons [0].GetComponent<Image> ().sprite = Red;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow) && selected != 0) {
			Buttons [selected].GetComponent<Image> ().sprite = Blue;
			selected--;
			Buttons [selected].GetComponent<Image> ().sprite = Red;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && selected != Buttons.Length - 1) {
			Buttons [selected].GetComponent<Image> ().sprite = Blue;
			selected++;
			Buttons [selected].GetComponent<Image> ().sprite = Red;
		}

		if (Input.GetKeyDown(KeyCode.Space))
			Buttons [selected].onClick.Invoke ();
	}
}
