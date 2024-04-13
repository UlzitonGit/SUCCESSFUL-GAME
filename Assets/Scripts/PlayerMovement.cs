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
    public float dashPower = 20;
    private bool isFacingRight = true;
    private bool _isGrounded = false;
    private float windSpeed = 250f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    PlayerAttack pla;
    bool canJump = true;
    public int jump = 1;
    // Start is called before the first frame update
    void Start()
    {
        pla = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        _isGrounded = IsGrounded() && canJump == true;
        if (_isGrounded == true && pla.isEvil == true) jump = 1;
        if (_isGrounded == true && pla.isEvil == false) jump = 2;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if(Input.GetButton("Jump") && jump > 0 && canJump == true)
        {
            Jump();
            StartCoroutine(ReloadDash());
        }
        //if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        //{
            //JumpLow();
        //}
        
    }
    private void Jump()
    {
        jump -= 1;
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
    private void Floating()
    {
        rb.velocity = new Vector2(rb.velocity.x, windSpeed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            Floating();
        }
    }
    IEnumerator ReloadDash()
    {
        canJump = false;
        yield return new WaitForSeconds(0.2f);
        canJump = true;
    }
    
}
