using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤 인스턴스를 저장할 정적 변수
    public Transform[] spawnPoints;
    public GameObject[] obstacles;

    public float spawnDelay; // 스폰되는 시간 간격
    private float spawnTimer; // 스폰하기 위한 타이머(시간을 재기 위한 변수)
    public bool isSpawning; // 스폰을 하기 위한 변수, true면 스폰 되고, false면 스폰이 되지 않는다.
    private int spawnTracker; // 어떤 장애물을 스폰할지 픽하기 위한 변수 ( 0 : 선인장1, 1: 선인장2, 2: 선인장3, 3 : 선인장4, 4 : 익룡 )
    public int mainScore; // 실제로 게임 도중 1씩 더해질 int형 변수
    public TextMeshProUGUI mainScore_text; // 게임 화면의 우측 상단의 ScoreText(TMP)오브젝트의 Text 부분을 담기 위한 변수.
    public GameObject gameOver_Panel; // GameOver 윈도우 패널 GameOver시에 창을 활성화 해주기 위한 변수.
    public TextMeshProUGUI bestScore_text; // 나의 역대 최고 점수 BestScoreText.
    public TextMeshProUGUI endScore_text; // 게임이 끝났을 때 ScoreText

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this; // 인스턴스가 존재하지 않으면 현재 오브젝트를 인스턴스로 설정하고 유지
        }
    }
    void Start()
    {
        spawnTimer = spawnDelay;
    }
    void Update()
    {
        {
            if (isSpawning.Equals(true)) // true일 때 스폰 시작
            {
                spawnTimer -= Time.deltaTime; // 딜레이 시간을 잰다
                if (spawnTimer < 0) // 타이머의 값이 점점 빠져서 0보다 작게 되면
                {
                    spawnTimer = spawnDelay; // 다시 타이머의 시간을 스폰되는 시간으로 리셋
                    spawnTracker = Random.Range(0, obstacles.Length); // 선인장일지, 익룡이 나올지 정한다
                    if (spawnTracker.Equals(4)) // 4가 나와서 익룡이 걸렸다면
                    {
                        int randPoint = 2 + Random.Range(0, 3); // spawnPoints중에서 배열의 index번호가 2부터 익룡 포인트기 때문에 2를 더한다( Randmom.Range(0,3)하면 나올 수 있는 수는 0,1,2 중에 1개가 나온다)
                        Instantiate(obstacles[spawnTracker], spawnPoints[randPoint].position, spawnPoints[randPoint].rotation); // 정해진 포인트에서 생성 ( 포인트는 spawnPoints배열의 인덱스번호 2,3,4 중에 1개가 정해질 것이다)
                    }
                    else if (spawnTracker.Equals(0)) // 선인장 1이 선택되었다면
                    {
                        Instantiate(obstacles[spawnTracker], spawnPoints[spawnTracker].position, spawnPoints[spawnTracker].rotation); // spawnPoints배열 중에 인덱스 번호 0번의 위치에서 생성
                    }
                    else // 그외의 장애물(선인장2,3,4)가 선택되었다면
                    {
                        Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[1].rotation); // spawnPoints 배열의 인덱스 번호 1번의 위치에서 생성
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("게임 오버");
        }
        else if (collision.CompareTag("Point"))
        {
            GameManager.instance.Score_UI_Update(); // 싱글톤을 접근 가능한 인스턴스를 통해 Score_UI_Update함수에 바로 접근.
        }
    }
    public void Score_UI_Update()
    {
        mainScore++; // mainScore 변수에 1을 더한다.
        mainScore_text.text ="스코어 : " + mainScore.ToString(); // mainScoreText에 mainScore변수 값 출력
    }
    public void GameOver()
    {
        Time.timeScale = 0f; // Unity에서 게임의 시간 흐름을 멈춤.
        if (mainScore > PlayerPrefs.GetInt("BestScore",0)) // 현재 메인 점수가, 저장돼 있던 베스트 점수(없다면 기본값은 0)보다 높다면
        {
            PlayerPrefs.SetInt("BestScore", mainScore); // 베스트 점수에 메인 점수를 넣어주고 저장.
        }
        bestScore_text.text = "Best Score : " + PlayerPrefs.GetInt("BestScore").ToString(); // 베스트 점수는 저장되어있던 베스트 점수를 불러서 보여줌.
        endScore_text.text = "Score : " + mainScore.ToString(); // 마지막 점수는 MainScore점수를 문자화 해서 넣어줌.
        gameOver_Panel.SetActive(true); // GameOver패널 활성화.
    }
    public void RestartGame()
    {
    }


}

