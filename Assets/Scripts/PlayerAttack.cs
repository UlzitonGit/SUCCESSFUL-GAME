using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1;
    public bool isEvil = false;
    bool canAttack = true;
    [SerializeField] GameObject attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEvil == false) return;
        if(Input.GetKey(KeyCode.Mouse0) && canAttack == true) 
        {
            StartCoroutine(Attacking());
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
}
