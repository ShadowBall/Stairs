using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public bool jumped = false;
    public bool died = false;
    public bool parachuted = false;
    public bool crystaled = false;
    public bool revive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log("XD");
        //Debug.Log(jumped);
        //JumpFun();
    }
    // Update is called once per frame
    public void JumpFun()
    {
        Debug.Log("XD22222222");
        Debug.Log(jumped);
        if (jumped == true)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

    }

    public void DiedFun()
    {
        if (died == true)
        {
            animator.SetBool("isDying", true);
        }
        else
        {
            animator.SetBool("isDying", false);
        }
    }

    public void ParachuteFun()
    {
        if (parachuted == true)
        {
            animator.SetBool("hasParachute", true);
        }
        else
        {
            animator.SetBool("hasParachute", false);
        }
    }

    public void CrystalFun()
    {
        if (crystaled == true)
        {
            animator.SetBool("hasCrystal", true);
        }
        else
        {
            animator.SetBool("hasCrystal", false);
        }
    }

    public void ReviveFun()
    {
        if (revive == true)
        {
            animator.SetBool("isRevived", true);
        }
        else
        {
            animator.SetBool("isRevived", false);
        }
    }

}
