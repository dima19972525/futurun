using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public float Speed = 7.0f;
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        position.x += Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        position.y += Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        GetComponent<Rigidbody2D>().MovePosition(position );
        
	}
}
