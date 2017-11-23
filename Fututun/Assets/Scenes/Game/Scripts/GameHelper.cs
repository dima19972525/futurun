using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour {

    public Transform EnemySpawn;
    public GameObject[] Enymies;

    private float cameraHeight;
	// Use this for initialization
	void Start () {
        GameState.State = GameState.States.PLAY;
        cameraHeight = Camera.main.orthographicSize * 2.0f;
        StartCoroutine(spawnEnemy());
	}
	

    IEnumerator spawnEnemy()
    {
        int typeEnemy = Random.Range(0, Enymies.Length);
        Vector2 pos = new Vector2(EnemySpawn.position.x, 
            Random.Range(-cameraHeight / 2, cameraHeight / 2));
        Instantiate(Enymies[typeEnemy], pos, Quaternion.identity);

        float seconds = Random.Range(0.3f, 1.0f);
        if (GameState.State != GameState.States.PLAY)
        {
            GameObject[] o = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var i in o)
                i.GetComponent<Enemy>().Kill();
            
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(seconds);

            StartCoroutine(spawnEnemy());
        }
    }
}
