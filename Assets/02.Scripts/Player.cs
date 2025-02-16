using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;  // 점프 힘 설정
    private bool isGround = true;  // 플레이어가 땅에 있는지 확인
    private Rigidbody2D rb;  // Rigidbody2D 참조
    private Animator anim;  // Animator 참조

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("isGround", true);
    }

    void Update()
    {
        // 스페이스 키를 누르면 Jump 애니메이션 실행 + 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");  // Jump 애니메이션 실행
            anim.SetBool("isGround", false);  // 점프 중이므로 isGround = false
            isGround = false;
        }
    }

    // 착지 감지
   
    }

