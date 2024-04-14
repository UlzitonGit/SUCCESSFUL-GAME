using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] Vector2 dir;
    public float dirT = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroying());
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(dir * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject.layer == 6)
        {
            collision.GetComponent<PlayerHealth>().GetDamageCheck(0.1f);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 3)
        {
           
            Destroy(gameObject);
        }
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
