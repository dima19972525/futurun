using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public float Speed = 7.0f;
    public GameObject Bullet;
    public Transform BulletSpawn;
	
	// Update is called once per frame
	void Update () {
		if (GameState.State == GameState.States.PLAY) {
			Vector2 position = transform.position;
			position.x += Input.GetAxis ("Horizontal") * Time.deltaTime * Speed;
			position.y += Input.GetAxis ("Vertical") * Time.deltaTime * Speed;
			GetComponent<Rigidbody2D> ().MovePosition (position);

			if (Input.GetKeyUp (KeyCode.Space))
				shoot ();
		}
	}

    private void shoot()
    {
        Instantiate(Bullet, BulletSpawn.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if (e != null)
            Kill();
    }

    public void Kill()
    {
		GameState.State = GameState.States.GAME_OVER;
        GetComponent<Animator>().SetTrigger("Kill");
		GetComponent<AudioSource> ().Play();
    }
    
    public void Death()
    {
        Destroy(this.gameObject);
    }
}
