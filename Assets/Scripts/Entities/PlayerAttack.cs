using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject attackCollider;
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem attack;
    [SerializeField] ParticleSystem part;
    public float timeBetweenAttacks = 1;
    private bool canAttack = true;
    [SerializeField] PlayerMovementDescription[] _playerMovementDescription;
    AudioSource _aud;
    [SerializeField] AudioClip[] _audClip;
    PlayerMovement pl;
    bool canDash = true;

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
        yield return new WaitForSeconds(0.3f);
        _aud.PlayOneShot(_audClip[Random.Range(0, _audClip.Length)]);
        yield return new WaitForSeconds(0.4f);
        if(pl._isGrounded == true)attack.Play();
        yield return new WaitForSeconds(timeBetweenAttacks);
        yield return new WaitForSeconds(0.3f);
        _playerMovementDescription[0].canSwitch = true;
        _playerMovementDescription[1].canSwitch = true;
        canAttack = true;
    }
    IEnumerator Dashing()
    {
        //_playerMovementDescription.canSwitch = false;
        part.Play();
        canDash = false;
        pl.gameObject.layer = 7;
        anim.SetTrigger("Dash");
        pl.Dash();
        yield return new WaitForSeconds(0.3f);
        pl.gameObject.layer = 6;
        yield return new WaitForSeconds(1f);
        //_playerMovementDescription.canSwitch = true;
        canDash = true;
    }
}
