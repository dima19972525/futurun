using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGameScene : MonoBehaviour {

    public Transform BackGround;
    public BoxCollider2D Ground, Sky, LeftWall, 
        RightWall, EndPlace;
    public GameObject Hero;
    public Transform HeroSpawn;

    private const float wallSize = 1.0f;

    void Awake() {
        // Подгоняем размеры фона, под размеры камеры
        float v = Camera.main.orthographicSize * 2.0f;
        float h = v * Screen.width / Screen.height;
        BackGround.localScale = new Vector3(h, v, 1);
		BackGround.transform.position = Camera.main.rect.position;
        
        // Настройка размеров коллайдеров 
        Ground.size = new Vector2(h, wallSize);
        Sky.size = Ground.size;
        LeftWall.size = new Vector2(wallSize, v);
        RightWall.size = LeftWall.size;
        EndPlace.size = LeftWall.size;

        Instantiate(Hero, HeroSpawn.position, Quaternion.identity);
    }
}
