using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
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
