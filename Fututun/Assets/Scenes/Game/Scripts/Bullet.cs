using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 15.0f;
    public int Damage = 1;
    
	// Update is called once per frame
	void Update () {
		if (GameState.State == GameState.States.PLAY) {
			transform.position = new Vector2 (transform.position.x + Speed * Time.deltaTime,
				transform.position.y);
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if (e != null)
            e.Hit(Damage);

        Destroy(this.gameObject);
    }
}
