using UnityEngine;

public class SpikeDeath : MonoBehaviour
{     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().GetDamageCheck(0.2f);
        }
    }
}
