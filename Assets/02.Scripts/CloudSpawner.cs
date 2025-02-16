using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float speed = 2f; // 구름 이동 속도
    public float minY = 1f; // 최소 Y 좌표
    public float maxY = 4f; // 최대 Y 좌표
    public float minX = -11f; // 구름이 사라지는 X 좌표
    public float respawnX = 11f; // 구름이 다시 생성될 X 좌표

    void Update()
    {
        // 왼쪽으로 이동
        transform.position += Vector3.left * speed * Time.deltaTime;

        // 만약 X 좌표가 minX보다 작으면 다시 respawnX에서 랜덤 Y값으로 생성
        if (transform.position.x < minX)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // 새로운 Y 좌표 랜덤 설정
        float randomY = Random.Range(minY, maxY);

        // 새로운 위치 설정
        transform.position = new Vector3(respawnX, randomY, transform.position.z);
    }
}
