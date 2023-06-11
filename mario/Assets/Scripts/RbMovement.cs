using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RbMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private float GROUND_CHECK_RADIUS = 0.2f;
    private float horizontalVelocity = 0f;
    private float maxDistance = 0.3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private bool IsGrounded()
    {

        if (Physics2D.Raycast(groundCheck.position, groundCheck.TransformDirection(Vector2.right), 0.3f, groundLayer) ||
            Physics2D.Raycast(groundCheck.position, groundCheck.TransformDirection(Vector2.left), 0.5f, groundLayer) ||
            Physics2D.OverlapCircle(groundCheck.position, GROUND_CHECK_RADIUS, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Move(float horizontal, bool jumpDownBtn, bool jumpUpBtn)
    {
              
        animator.SetBool("move", horizontal!=0);

        if(jumpDownBtn&&IsGrounded())
            animator.SetTrigger("jump");

        animator.SetBool("fall", rb.velocity.y < 0 && IsGrounded() == false);
        
        if (jumpDownBtn && IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        if (jumpUpBtn && rb.velocity.y > 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        if (horizontal != 0f)
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            else {
                rb.velocity = new Vector2(horizontal * speed * 0.75f, rb.velocity.y);
            }
        }
        else
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        Flip(horizontal);
        //Debug.DrawRay(groundCheck.position, groundCheck.TransformDirection(Vector2.right) * maxDistance, Color.red);
        //Debug.DrawRay(groundCheck.position, groundCheck.TransformDirection(Vector2.left) * 0.5f, Color.red, 0.1f);
        //if (Physics2D.Raycast(groundCheck.position, groundCheck.TransformDirection(Vector2.right), 0.3f, groundLayer) ||
        //    Physics2D.Raycast(groundCheck.position, groundCheck.TransformDirection(Vector2.left), 0.5f, groundLayer))
        //{
        //    Debug.Log("HIT");

        //}
        //if (IsGrounded()) Debug.Log("HIT");
    }
    private void Flip(float horizontal)
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            var localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }
}
