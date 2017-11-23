using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour {

    public Transform EnemySpawn;
    public GameObject[] Enymies;
	public GameObject CanvasGameOver, CanvasPause;

    private float cameraHeight;
	// Use this for initialization
	void Start () {
        GameState.State = GameState.States.PLAY;
		Time.timeScale = 1.0f;

        cameraHeight = Camera.main.orthographicSize * 2.0f;
        StartCoroutine(spawnEnemy());
	}

	void Update() {
		if (GameState.State == GameState.States.PLAY || GameState.State == GameState.States.PAUSE) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				if (GameState.State == GameState.States.PLAY) {
					GameState.State = GameState.States.PAUSE;
					Time.timeScale = 0.0f;
				} else {
					GameState.State = GameState.States.PLAY;
					Time.timeScale = 1.0f;
				}
				CanvasPause.SetActive (!CanvasPause.activeSelf);
			}
		}
	}

    IEnumerator spawnEnemy()
    {
        int typeEnemy = Random.Range(0, Enymies.Length);
        Vector2 pos = new Vector2(EnemySpawn.position.x, 
            Random.Range(-cameraHeight / 2, cameraHeight / 2));
        Instantiate(Enymies[typeEnemy], pos, Quaternion.identity);

        float seconds = Random.Range(0.3f, 1.0f);
		switch (GameState.State) {

		case GameState.States.GAME_OVER:
			GameObject[] o = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (var i in o)
				i.GetComponent<Enemy> ().Kill ();
			yield return null;
			CanvasGameOver.SetActive(true);
			break;

		case GameState.States.PLAY:
			yield return new WaitForSeconds(seconds);
			StartCoroutine(spawnEnemy());
			break;

		}
    }
}
