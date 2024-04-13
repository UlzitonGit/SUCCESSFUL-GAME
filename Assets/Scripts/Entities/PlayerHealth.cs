
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image hpBar;
    float health = 1;
    bool canBeDamaged = true;
    PlayerAttack pl;
    private void Start()
    {
        pl = GetComponent<PlayerAttack>();
    }
    public void GetDamage(float damage)
    {
        if (canBeDamaged == false) return;
        StartCoroutine(Immortallity());
        health -= damage;
        hpBar.fillAmount = health;
        if(health <= 0.05f)
        {
            Death();
        }
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHit"))
        {
            GetDamage(0.2f);
        }
    }
    IEnumerator Immortallity()
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(0.2f);
        canBeDamaged = true;
    }
    public void StartHealing()
    {
        StartCoroutine(PassiveHeal());
    }
    IEnumerator PassiveHeal()
    {
        if(pl.isEvil == false && health < 1)
        {
            health += 0.005f;
            hpBar.fillAmount = health;
            yield return new WaitForSeconds(0.15f);
            if (health > 1) health = 1;
            StartCoroutine(PassiveHeal());
        }
        

    }
}
