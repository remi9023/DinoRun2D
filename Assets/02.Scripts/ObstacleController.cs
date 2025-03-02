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

   

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
