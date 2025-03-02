using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;

    public float spawnDelay; // �����Ǵ� �ð� ����
    private float spawnTimer; // �����ϱ� ���� Ÿ�̸�(�ð��� ��� ���� ����)
    public bool isSpawning; // ������ �ϱ� ���� ����, true�� ���� �ǰ�, false�� ������ ���� �ʴ´�.
    private int spawnTracker; // � ��ֹ��� �������� ���ϱ� ���� ���� ( 0 : ������1, 1: ������2, 2: ������3, 3 : ������4, 4 : �ͷ� )
    void Start()
    {
        spawnTimer = spawnDelay;
    }
    void Update()
    {
        {
            if (isSpawning.Equals(true)) // true�� �� ���� ����
            {
                spawnTimer -= Time.deltaTime; // ������ �ð��� ���
                if (spawnTimer < 0) // Ÿ�̸��� ���� ���� ������ 0���� �۰� �Ǹ�
                {
                    spawnTimer = spawnDelay; // �ٽ� Ÿ�̸��� �ð��� �����Ǵ� �ð����� ����
                    spawnTracker = Random.Range(0, obstacles.Length); // ����������, �ͷ��� ������ ���Ѵ�
                    if (spawnTracker.Equals(4)) // 4�� ���ͼ� �ͷ��� �ɷȴٸ�
                    {
                        int randPoint = 2 + Random.Range(0, 3); // spawnPoints�߿��� �迭�� index��ȣ�� 2���� �ͷ� ����Ʈ�� ������ 2�� ���Ѵ�( Randmom.Range(0,3)�ϸ� ���� �� �ִ� ���� 0,1,2 �߿� 1���� ���´�)
                        Instantiate(obstacles[spawnTracker], spawnPoints[randPoint].position, spawnPoints[randPoint].rotation); // ������ ����Ʈ���� ���� ( ����Ʈ�� spawnPoints�迭�� �ε�����ȣ 2,3,4 �߿� 1���� ������ ���̴�)
                    }
                    else if (spawnTracker.Equals(0)) // ������ 1�� ���õǾ��ٸ�
                    {
                        Instantiate(obstacles[spawnTracker], spawnPoints[spawnTracker].position, spawnPoints[spawnTracker].rotation); // spawnPoints�迭 �߿� �ε��� ��ȣ 0���� ��ġ���� ����
                    }
                    else // �׿��� ��ֹ�(������2,3,4)�� ���õǾ��ٸ�
                    {
                        Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[1].rotation); // spawnPoints �迭�� �ε��� ��ȣ 1���� ��ġ���� ����
                    }
                }
            }
        }
    }
}
