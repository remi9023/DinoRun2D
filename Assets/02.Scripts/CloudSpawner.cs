using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float speed = 2f; // ���� �̵� �ӵ�
    public float minY = 1f; // �ּ� Y ��ǥ
    public float maxY = 4f; // �ִ� Y ��ǥ
    public float minX = -11f; // ������ ������� X ��ǥ
    public float respawnX = 11f; // ������ �ٽ� ������ X ��ǥ

    void Update()
    {
        // �������� �̵�
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ���� X ��ǥ�� minX���� ������ �ٽ� respawnX���� ���� Y������ ����
        if (transform.position.x < minX)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // ���ο� Y ��ǥ ���� ����
        float randomY = Random.Range(minY, maxY);

        // ���ο� ��ġ ����
        transform.position = new Vector3(respawnX, randomY, transform.position.z);
    }
}
