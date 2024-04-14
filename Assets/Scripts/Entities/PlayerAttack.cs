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

    PlayerMovement pl;
    bool canDash = true;

    public bool isEvil = false;

    void Start()
    {
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
        
        pl.StackInAir();
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.7f);
        if(pl._isGrounded == true)attack.Play();
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }
    IEnumerator Dashing()
    {
        part.Play();
        canDash = false;
        pl.gameObject.layer = 7;
        anim.SetTrigger("Dash");
        pl.Dash();
        yield return new WaitForSeconds(0.3f);
        pl.gameObject.layer = 6;
        yield return new WaitForSeconds(0.7f);
        canDash = true;
    }
}
