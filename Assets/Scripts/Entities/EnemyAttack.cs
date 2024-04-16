using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject _hit;
    bool  canAttack = true;
    public bool isDeath = false;
    Animator anim;
    public void Attack()
    {
        if (canAttack == false) return;
        if (isDeath == true) return;
        anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(Attacking());
    }
    IEnumerator Attacking()
    {
        canAttack = false;
        _hit.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _hit.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        canAttack = true;
    }
}
