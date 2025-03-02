using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱��� �ν��Ͻ��� ������ ���� ����
    public Transform[] spawnPoints;
    public GameObject[] obstacles;

    public float spawnDelay; // �����Ǵ� �ð� ����
    private float spawnTimer; // �����ϱ� ���� Ÿ�̸�(�ð��� ��� ���� ����)
    public bool isSpawning; // ������ �ϱ� ���� ����, true�� ���� �ǰ�, false�� ������ ���� �ʴ´�.
    private int spawnTracker; // � ��ֹ��� �������� ���ϱ� ���� ���� ( 0 : ������1, 1: ������2, 2: ������3, 3 : ������4, 4 : �ͷ� )
    public int mainScore; // ������ ���� ���� 1�� ������ int�� ����
    public TextMeshProUGUI mainScore_text; // ���� ȭ���� ���� ����� ScoreText(TMP)������Ʈ�� Text �κ��� ��� ���� ����.
    public GameObject gameOver_Panel; // GameOver ������ �г� GameOver�ÿ� â�� Ȱ��ȭ ���ֱ� ���� ����.
    public TextMeshProUGUI bestScore_text; // ���� ���� �ְ� ���� BestScoreText.
    public TextMeshProUGUI endScore_text; // ������ ������ �� ScoreText

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this; // �ν��Ͻ��� �������� ������ ���� ������Ʈ�� �ν��Ͻ��� �����ϰ� ����
        }
    }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("���� ����");
        }
        else if (collision.CompareTag("Point"))
        {
            GameManager.instance.Score_UI_Update(); // �̱����� ���� ������ �ν��Ͻ��� ���� Score_UI_Update�Լ��� �ٷ� ����.
        }
    }
    public void Score_UI_Update()
    {
        mainScore++; // mainScore ������ 1�� ���Ѵ�.
        mainScore_text.text ="���ھ� : " + mainScore.ToString(); // mainScoreText�� mainScore���� �� ���
    }
    public void GameOver()
    {
        Time.timeScale = 0f; // Unity���� ������ �ð� �帧�� ����.
        if (mainScore > PlayerPrefs.GetInt("BestScore",0)) // ���� ���� ������, ����� �ִ� ����Ʈ ����(���ٸ� �⺻���� 0)���� ���ٸ�
        {
            PlayerPrefs.SetInt("BestScore", mainScore); // ����Ʈ ������ ���� ������ �־��ְ� ����.
        }
        bestScore_text.text = "Best Score : " + PlayerPrefs.GetInt("BestScore").ToString(); // ����Ʈ ������ ����Ǿ��ִ� ����Ʈ ������ �ҷ��� ������.
        endScore_text.text = "Score : " + mainScore.ToString(); // ������ ������ MainScore������ ����ȭ �ؼ� �־���.
        gameOver_Panel.SetActive(true); // GameOver�г� Ȱ��ȭ.
    }
    public void RestartGame()
    {
    }


}

