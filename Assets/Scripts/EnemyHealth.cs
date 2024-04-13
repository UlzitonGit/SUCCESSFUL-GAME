using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 1;
    [SerializeField] Image hpBar;
    bool canBeDamaged = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack") && canBeDamaged == true)
        {
            StartCoroutine(Immortality());
            health -= 0.35f;
            hpBar.fillAmount = health;
            if (health <= 0) Destroy(gameObject);
        }
    }
    IEnumerator Immortality()
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(0.2f);
        canBeDamaged = true;
    }
}
