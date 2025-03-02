using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
   public float moveSpeedX;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(moveSpeedX, 0f); // 리지드바디의 선형 속도(초당 단위)를 나타냅니다.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("선인장과 충돌했다!!");
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
