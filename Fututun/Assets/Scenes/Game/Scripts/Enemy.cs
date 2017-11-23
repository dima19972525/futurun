using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int Health = 6;
    public float Speed = 5.0f;
    public float SpeedRotation = 70.0f;

	// Update is called once per frame
	void Update () {
		if (GameState.State == GameState.States.PLAY) {
			transform.position = new Vector2 (transform.position.x - Speed * Time.deltaTime,
				transform.position.y);
			transform.Rotate (Vector3.forward * SpeedRotation * Time.deltaTime);
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EndPlace>())
            Kill();
    }

    public int Hit(int damage)
    {
        GetComponent<Animator>().SetTrigger("Hit");
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            Kill();
        }

        return Health;
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
