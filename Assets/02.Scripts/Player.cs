using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;  // ���� �� ����
    private bool isGround = true;  // �÷��̾ ���� �ִ��� Ȯ��
    private Rigidbody2D rb;  // Rigidbody2D ����
    private Animator anim;  // Animator ����

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("isGround", true);
    }

    void Update()
    {
        // �����̽� Ű�� ������ Jump �ִϸ��̼� ���� + ����
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");  // Jump �ִϸ��̼� ����
            anim.SetBool("isGround", false);  // ���� ���̹Ƿ� isGround = false
            isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // ����� �浹���� ��
        {
            isGround = true;
            anim.SetBool("isGround", true);  // �ٽ� �޸��� �ִϸ��̼� ����
        }
    }
    // ���� ����

}

