using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{ 
    public float bgspeed;
    public Renderer bgRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    bgRenderer.material.mainTextureOffset += new Vector2(bgspeed * Time.deltaTime, 0f);

    }
}
