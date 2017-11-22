using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMainScene : MonoBehaviour {

    public Button StartButton;
    public Button ExitButton;

    private Sprite red, blue;
    private short selected;
    void Start()
    {
        red = StartButton.GetComponent<Image>().sprite;
        blue = ExitButton.GetComponent<Image>().sprite;
        selected = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && selected == 2)
        {
            StartButton.GetComponent<Image>().sprite = red;
            ExitButton.GetComponent<Image>().sprite = blue;
            selected = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) && selected == 1)
        {
            StartButton.GetComponent<Image>().sprite = blue;
            ExitButton.GetComponent<Image>().sprite = red;
            selected = 2;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (selected == 1)
                StartButton.onClick.Invoke();
            else
                ExitButton.onClick.Invoke();
        }

    }
}
