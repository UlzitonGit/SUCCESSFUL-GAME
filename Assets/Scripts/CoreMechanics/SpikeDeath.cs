using System.Collections;
using UnityEngine;

public class SpikeDeath : MonoBehaviour
{
    bool canDamage = true;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canDamage == true)
        {
            FindObjectOfType<PlayerHealth>().GetDamageCheck(0.2f);
            StartCoroutine(ReloadDamage());
        }
    }
    IEnumerator ReloadDamage()
    {
        canDamage = false;
        yield return new WaitForSeconds(1);
        canDamage = true;
    }

}
