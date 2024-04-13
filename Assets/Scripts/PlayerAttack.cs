using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1;
    public bool isEvil = false;
    bool canAttack = true;
    [SerializeField] GameObject attackCollider;
    [SerializeField] Animator anim;
    PlayerMovement pl;
    bool canDash = true;
    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEvil == false) return;
        if(Input.GetKey(KeyCode.Mouse0) && canAttack == true) 
        {
            StartCoroutine(Attacking());
        }
        if (Input.GetKey(KeyCode.Mouse1) && canDash == true)
        {
            StartCoroutine(Dashing());
        }
    }
    IEnumerator Attacking()
    {
        canAttack = false;
        attackCollider.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackCollider.SetActive(false);
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }
    IEnumerator Dashing()
    {
        canDash = false;
        pl.gameObject.layer = 7;
        anim.SetTrigger("Dash");
        yield return new WaitForSeconds(0.5f);
        pl.gameObject.layer = 6;
        yield return new WaitForSeconds(1f);
        canDash = true;
    }
}
