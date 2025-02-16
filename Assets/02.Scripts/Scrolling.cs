using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    // 특정 오브젝트를 움직이거나 이동시킬때는 무조건 이동속도에 대한 변수선언이 필요하다.

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
