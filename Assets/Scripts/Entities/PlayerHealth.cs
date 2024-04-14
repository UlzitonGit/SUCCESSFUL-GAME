
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Transform[] checkPoint;
    [SerializeField] Image hpBar;
    [SerializeField] TextMeshProUGUI HPtext;
    public float health = 1;
    public float healthToText;
    bool canBeDamaged = true;
    PlayerAttack pl;
    public Transform currentCheckPoint;
    public int checkPointNumber = 0;
    bool getDamage = false;
    PlayerAttack pla;
    private void Start()
    {
        pla = GetComponent<PlayerAttack>();
        checkPointNumber = PlayerPrefs.GetInt("CheckPoint");
        if(currentCheckPoint == null) currentCheckPoint = checkPoint[checkPointNumber];
        transform.position = currentCheckPoint.position;
        pl = GetComponent<PlayerAttack>();
        healthToText = health * 100;
        FindObjectOfType<PlayerMovementDescription>().FirtsIteration();
    }
    public void Death()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHit"))
        {
            GetDamageCheck(0.2f);
        }
        if (collision.CompareTag("CheckPoint"))
        {
            if(collision.GetComponent<CheckPointID>().number > currentCheckPoint.GetComponent<CheckPointID>().number)
            {
                currentCheckPoint = collision.transform;
                PlayerPrefs.SetInt("CheckPoint", currentCheckPoint.GetComponent<CheckPointID>().number);
            }
            
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

        if(pl.isEvil == false && health < 1 && getDamage ==false)
        {
            health += 0.0025f;
            hpBar.fillAmount = health;
            yield return new WaitForSeconds(0.15f);
            if (health > 1) health = 1;
            StartCoroutine(PassiveHeal());
        }
    }
    public void GetDamageCheck(float damage)
    {
        if (canBeDamaged == false) return;
        StartCoroutine(GetDamage(damage));
    }
    public void DeathZoneF()
    {
        health = 0;
        Death();
    }
    IEnumerator GetDamage(float damage)
    {
        getDamage = true;
        StartCoroutine(Immortallity());
        for (float i = 0; i < damage; i += 0.05f)
        {
            health -= 0.05f;
            hpBar.fillAmount = health;
            HPtext.text = Mathf.RoundToInt(health * 100).ToString() + "/" + healthToText;
            yield return new WaitForSeconds(0.1f);
        }
        getDamage = false;
        if (pla.isEvil == false) StartCoroutine(PassiveHeal());
        if (health <= 0.05f)
        {
            Death();
        }
    }
}
