using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public float Speed = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameState.State == GameState.States.PLAY)
        {
            Vector2 offset = new Vector2(Time.time * Speed, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
	}
}
