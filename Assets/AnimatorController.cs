using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    PlayerMovement player;
    public Animator animator;
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SetAnimate();
    }
    private void SetAnimate()
    {
        if (player.moveInput != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if(player.isGrounded==false)
        {
            animator.SetBool("isGround", false);
        }
        else
        {
            animator.SetBool("isGround", true);
        }
        if (player.rb.velocity.y > 0)
        {
            animator.SetBool("up", true);
        }
        else
        {
            animator.SetBool("up", false);
        }
    }
}
