using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    // Ư�� ������Ʈ�� �����̰ų� �̵���ų���� ������ �̵��ӵ��� ���� ���������� �ʿ��ϴ�.

    public bool isCloud;
    public float cloudScrollSpeedX = 0.5f;

    [Header("Settings")]
    public float scrollSpeed;


    [Header("Referfences")]
    public MeshRenderer meshRenderer;

    
    void Start()
    {
        
    }

   
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed*Time.deltaTime, 0);   
    }
}
