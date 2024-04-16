using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceAttack : MonoBehaviour
{
    PlayerMovement pl;
    public bool isDeath = false;
    [SerializeField] GameObject bullet;
    [SerializeField] Animator animator;
    bool canAttack = true;
    float rotZ = 0;
    private void Start()
    {
        pl = FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
         Vector3 difference = pl.transform.position - transform.position;
         rotZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        
    }
    // Start is called before the first frame update
    public void Attack(float dir)
    {
        if (canAttack == false) return;
        if (isDeath == true) return;
        GameObject bulletD = Instantiate(bullet, transform.position, transform.rotation);
        animator.SetTrigger("Attack");
        StartCoroutine(Reload());
    }
    IEnumerator Reload()
    {
        canAttack = false;
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }
}
