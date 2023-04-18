using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationMovement : MonoBehaviour
{
    public GameObject player;

    private IlyaMovement movementscript;
    private Animator chAnimator;
    private Transform WASD, playerTransform;
    private Vector3 moveVector;

    void Start()
    {
        movementscript = player.GetComponent<IlyaMovement>();
        Vector3 moveVector = Vector3.zero;
        chAnimator = player.GetComponent<Animator>();
        playerTransform = player.GetComponent<Transform>();
        WASD = GetComponent<Transform>();
    }

    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        WASD.position = new Vector3(playerTransform.position.x + moveVector.x, 0f, playerTransform.position.z + moveVector.z);

        if(moveVector.x == 0 && moveVector.z == 0)
        {
            chAnimator.SetBool("Run", false);
        }
        /*else
        {
            chAnimator.SetBool("Run", true);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(movementscript.speedMove == 0f)
        {
            return;
        }

        chAnimator.SetBool("Run", true);

        switch (other.tag)
        {
            case "Front":
                chAnimator.SetFloat("x", 0);
                chAnimator.SetFloat("z", 1);
                break;
            case "Back":
                chAnimator.SetFloat("x", 0);
                chAnimator.SetFloat("z", -1);
                break;
            case "Left":
                chAnimator.SetFloat("x", -1);
                chAnimator.SetFloat("z", 0);
                break;
            case "Right":
                chAnimator.SetFloat("x", 1);
                chAnimator.SetFloat("z", 0);
                break;
            /*case "LeftFront":
                chAnimator.SetFloat("x", -1);
                chAnimator.SetFloat("z", 1);
                break;
            case "LeftBack":
                chAnimator.SetFloat("x", -1);
                chAnimator.SetFloat("z", -1);
                break;
            case "RightFront":
                chAnimator.SetFloat("x", 1);
                chAnimator.SetFloat("z", 1);
                break;
            case "RightBack":
                chAnimator.SetFloat("x", 1);
                chAnimator.SetFloat("z", -1);
                break;*/
        }
    }

    public void NullAnimationMovement()
    {
        chAnimator.SetBool("Forward", false);
        chAnimator.SetBool("Back", false);
    }
}
