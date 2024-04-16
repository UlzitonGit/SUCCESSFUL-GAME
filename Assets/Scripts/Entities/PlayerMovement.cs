using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 6f;
    public float dashPower = 20;
    private bool canWalk = true;

    public float jumpingPower = 11f;
    private bool canJump = true;
    public int jump = 1;
    private float dashing = 1;

    private bool isFacingRight = true;
    public bool _isGrounded = false;
    private float windSpeed = 250f;

    private bool isDashing = false;
    private int dashDirection;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] Animator anim1;
    [SerializeField] Animator anim;
    PlayerAttack pla;

    bool playFallSound = true;
    bool isPlayingWalk = false;
    [SerializeField] Image dashBar;
    [SerializeField] AudioSource _audWalk;
    [SerializeField] AudioSource _audJump;
    [SerializeField] AudioClip walkSfx;
    [SerializeField] AudioClip jumpSfx;
    [SerializeField] AudioClip fallSfx;
    [SerializeField] AudioClip windSfx;
    [SerializeField] AudioSource _airWind;
    void Start()
    {
        pla = GetComponent<PlayerAttack>();
        dashBar.fillAmount = dashing;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        _isGrounded = IsGrounded() && canJump == true;
        if (_isGrounded == true && pla.isEvil == true) jump = 1;
        if (_isGrounded == true && pla.isEvil == false) jump = 2;
        anim.SetBool("Fall", !_isGrounded && pla.isEvil == false);
        anim1.SetBool("Fall", !_isGrounded && pla.isEvil == true);
    }

    private void FixedUpdate()
    {
        if(isDashing == true)
        {
            rb.velocity = new Vector2(gameObject.transform.localScale.x * speed * 2, rb.velocity.y);
        }
        if (canWalk == false) return;
        anim.SetBool("Walk", horizontal != 0 && pla.isEvil == false);
        anim1.SetBool("Walk", horizontal != 0 && pla.isEvil == true);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if(Input.GetButton("Jump") && jump > 0 && canJump == true)
        {
            Jump();
            StartCoroutine(ReloadDash());
        }
        if (horizontal != 0 && _isGrounded == true && isPlayingWalk == false)
        {
            _audWalk.PlayOneShot(walkSfx);
            isPlayingWalk = true;
        }
        if (horizontal == 0 || _isGrounded == false)
        {
            _audWalk.Stop();
            isPlayingWalk = false;
        }
        if(_isGrounded == true && playFallSound == true)
        {
            _audJump.PlayOneShot(fallSfx);
            playFallSound = false;
        }
        if (_isGrounded == false) playFallSound = true;

    }

    private void Jump()
    {
        _audJump.PlayOneShot(jumpSfx);
        if(pla.isEvil == false) anim.SetTrigger("Jump");
        if (pla.isEvil == true) anim1.SetTrigger("Jump");
        jump -= 1;
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    public void Dash()
    {
        StartCoroutine(Dashing());
    }
    IEnumerator Dashing()
    {
        canWalk = false;
        canJump = false;
        isDashing = true;
        yield return new WaitForSeconds(0.3f);
        isDashing = false;
        canJump = true;
        canWalk = true;
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
        rb.gravityScale = 1;
        StartCoroutine(AirHolder());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            Floating();
            _airWind.enabled = true;
        }
        if (collision.CompareTag("WindHorizontal"))
        {
            FloatingHor();
            canWalk = false;
            _airWind.enabled = true;
        }
        if (collision.CompareTag("Finish")) SceneManager.LoadScene(3);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("WindHorizontal"))
        {
            
            canWalk = true;
            _airWind.enabled = false;
        }
        if (collision.CompareTag("Wind"))
        {
           
            _airWind.enabled = false;

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
