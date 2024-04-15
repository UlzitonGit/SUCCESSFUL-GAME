using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 1;
    [SerializeField] Image hpBar;
    bool canBeDamaged = true;
    [SerializeField] Animator anim;
    [SerializeField] GameObject shadow;
    [SerializeField] ParticleSystem part;
    [SerializeField] ParticleSystem part2;
    Canvas canvas;
    Rigidbody2D rb;
    bool sticked = false;
    PosIng pos;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = FindObjectOfType<PosIng>();
        canvas = GetComponentInChildren<Canvas>();
    }
    private void Update()
    {
        if(sticked == true)
        {
            pos = FindObjectOfType<PosIng>();
            transform.position = Vector3.Lerp(transform.position, pos.transform.position, Time.deltaTime * 10);
            Vector3 difference = pos.transform.position - transform.position;
            float rotZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack") && canBeDamaged == true)
        {
            part2.Play();
            StartCoroutine(Immortality());
            health -= 0.55f;
            hpBar.fillAmount = health;
            if(health <= 0) StartCoroutine(Death());
            
        }
    }
    IEnumerator Death()
    {
        
        rb.isKinematic =true;
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        
        sticked = true;
        canvas.gameObject.SetActive(false);
        shadow.SetActive(false);
        part.Play();
        yield return new WaitForSeconds(0.3f);
        
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
        rb.AddForce(rb.transform.forward * 5, ForceMode2D.Impulse);
        sticked = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    IEnumerator Immortality()
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(0.2f);
        canBeDamaged = true;
    }
}
