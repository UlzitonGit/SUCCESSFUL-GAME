using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 6f;
    public float dashPower = 20;
    private bool canWalk = true;

    public float jumpingPower = 11f;
    private bool canJump = true;
    public int jump = 1;

    private bool isFacingRight = true;
    private bool _isGrounded = false;
    private float windSpeed = 250f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    PlayerAttack pla;
    
    void Start()
    {
        pla = GetComponent<PlayerAttack>();
    }

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
        if (canWalk == false) return;
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if(Input.GetButton("Jump") && jump > 0 && canJump == true)
        {
            Jump();
            StartCoroutine(ReloadDash());
        }
        
    }

    private void Jump()
    {
        jump -= 1;
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
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
    private void Floating() => rb.velocity = new Vector2(rb.velocity.x, windSpeed * Time.deltaTime);
    private void FloatingHor() => rb.velocity = new Vector2(speed, rb.velocity.y * Time.deltaTime);
    public void StackInAir()
    {
        if (IsGrounded() == true) return;
        rb.gravityScale = 0;
        StartCoroutine(AirHolder());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            Floating();
        }
        if (collision.CompareTag("WindHorizontal"))
        {
            FloatingHor();
            canWalk = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("WindHorizontal"))
        {
            
            canWalk = true;
        }
    }
    IEnumerator AirHolder()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = 2;
    }
    IEnumerator ReloadDash()
    {
        canJump = false;
        yield return new WaitForSeconds(0.2f);
        canJump = true;
    }
    
}
