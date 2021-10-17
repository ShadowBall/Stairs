using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rb;
    private Vector2 playerDirection;
    //public Animator animator;
    // Start is called before the first frame update
    public float runSpeed;
    //float horizontalMove = 10f;
    public bool jump = false;
    public Transform TeleportTo;
    private bool m_FacingRight = true;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        //playerDirection = new Vector2(directionX, 0).normalized;
        if (Input.GetButtonDown("Jump"))
        {
            //PlayerPos();
        }
    }
    void PlayerPos()
    {
        // GameObject.Find("SpawnPoint").transform.position;
        //Vector3 plpos = GameObject.Find("Player").transform.position;
        //plpos = sppos;
    }
    void FixedUpdate()
    {
        //controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        //rb.velocity = new Vector2(playerDirection.x * runSpeed, 0);
        //jump = false;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
