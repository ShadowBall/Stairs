using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public SpawnPlatform sp;
    public Rigidbody2D rb;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        if (Input.GetButtonDown("Jump"))
        {
            
                CameraUp();
           
         }
    }

    void CameraUp()
    {
       // transform.position += rb.transform.position;


    }
}
