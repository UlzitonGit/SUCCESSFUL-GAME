using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject attackCollider;
    [SerializeField] GameObject reloadingImage;
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem attack;
    [SerializeField] ParticleSystem part;
    [SerializeField] Image dashBar;
    float dashing = 1;
    [SerializeField] Image reloadImage;
    public float timeBetweenAttacks = 1;
    private bool canAttack = true;
    [SerializeField] PlayerMovementDescription[] _playerMovementDescription;
    AudioSource _aud;
    [SerializeField] AudioClip[] _audClip;
    PlayerMovement pl;
    bool canDash = true;
    float reload = 1;
    public bool isEvil = false;

    void Start()
    {
        _aud = GetComponent<AudioSource>();
        pl = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (isEvil == false) return;
        if(Input.GetKey(KeyCode.Mouse0) && canAttack == true) StartCoroutine(Attacking());
        if (Input.GetKey(KeyCode.Mouse1) && canDash == true) StartCoroutine(Dashing());
    }
    IEnumerator Attacking()
    {
       
        canAttack = false;
        _playerMovementDescription[0].canSwitch = false;
        _playerMovementDescription[1].canSwitch = false;
        pl.StackInAir();
        anim.SetTrigger("Attack");
        StartCoroutine(ReloadShow());
        yield return new WaitForSeconds(0.2f);
        if(pl._isGrounded == true ) _aud.PlayOneShot(_audClip[0]);
        if (pl._isGrounded == false) _aud.PlayOneShot(_audClip[1]);
        yield return new WaitForSeconds(0.5f);
        if(pl._isGrounded == true)attack.Play();
        yield return new WaitForSeconds(timeBetweenAttacks);
        yield return new WaitForSeconds(0.3f);
        _playerMovementDescription[0].canSwitch = true;
        _playerMovementDescription[1].canSwitch = true;
        canAttack = true;
    }
    IEnumerator ReloadShow()
    {
        reloadingImage.SetActive(true);
        reload = 0;
        reloadImage.fillAmount = reload;
        for (int i = 0; i < 10; i++)
        {
            reload += 0.1f;
            reloadImage.fillAmount = reload;
            yield return new WaitForSeconds(0.13f);
            
        }
        reloadingImage.SetActive(false);
    }
    IEnumerator Dashing()
    {
        //_playerMovementDescription.canSwitch = false;
        part.Play();
        canDash = false;
        pl.gameObject.layer = 7;
        anim.SetTrigger("Dash");
        pl.Dash();
        StartCoroutine(reloadDashing());
        yield return new WaitForSeconds(0.3f);
        pl.gameObject.layer = 6;
        yield return new WaitForSeconds(1f);
        //_playerMovementDescription.canSwitch = true;
        canDash = true;
    }
    IEnumerator reloadDashing()
    {
        dashing = 0;
        dashBar.fillAmount = dashing;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.13f);
            dashing += 0.1f;
            dashBar.fillAmount = dashing;
        }
        
    }
}
