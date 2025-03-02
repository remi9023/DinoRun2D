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
        rb.velocity = new Vector2(moveSpeedX, 0f); // ������ٵ��� ���� �ӵ�(�ʴ� ����)�� ��Ÿ���ϴ�.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("������� �浹�ߴ�!!");
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
