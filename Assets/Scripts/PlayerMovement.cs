using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 6f;
    public float jumpingPower = 11f;
    private bool isFacingRight = true;
    private bool _isGrounded = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        _isGrounded = IsGrounded();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if(Input.GetButton("Jump") && _isGrounded == true)
        {
            Jump();
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            JumpLow();
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }
    private void JumpLow()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
