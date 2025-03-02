using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    public bool isDown;
    // offset�� size ���� ������ ����
    private Vector2 savedOffset;
    private Vector2 savedSize;
    // BoxCollider2D�� ������ ����
    private BoxCollider2D boxCollider;
    public Transform groundCheckPoint; // ���� ���� ��ġ
    public LayerMask whatIsGround; // Ground���� ���� LayerMask
    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();// BoxCollider2D ������Ʈ�� ������
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SaveColliderSettings();
        anim.SetBool("isGround", true); // ó���� Run �ִϸ��̼� ����
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Equals(true))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Dino�� ���ӵ��� y�������� jumpForce��ŭ �ش�.
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded.Equals(true)) //���� ���� ���¿��� �Ʒ� ȭ��ǥ Ű�� ������.
        {
            SetDownArrowDown();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) // �Ʒ� ȭ��ǥ Ű�� ����
        {
            SetDownArrowUp();
        }
        anim.SetBool("isGround", isGrounded); // isGrounded�� ���� ���� �ڵ����� �ִϸ��̼� ����
    }
    void SaveColliderSettings()
    {
        // ���� offset�� size ���� ����
        savedOffset = boxCollider.offset;
        savedSize = boxCollider.size;
    }
    void LoadColliderSettings()
    {
        // ����� offset�� size ���� BoxCollider2D�� �ٽ� ����
        boxCollider.offset = savedOffset;
        boxCollider.size = savedSize;
    }
  


    void SetDownArrowDown()
    {
        anim.SetBool("isDown", true); // Dino���ϸ����Ϳ��� ���� isDown�� true��
        boxCollider.offset = new Vector2(0, -0.25f);
        boxCollider.size = new Vector2(1.39f, 0.76f);
    }
    void SetDownArrowUp()
    {
        anim.SetBool("isDown", false); // Dino���ϸ����Ϳ��� ���� isDown�� false��
        LoadColliderSettings();
    }
    void OnDrawGizmos() // ���� �׸���
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.2f);
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
}
   
