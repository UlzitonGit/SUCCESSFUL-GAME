using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerD : MonoBehaviour
{
    [SerializeField] GameObject[] images;
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
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            for (int i = 0; i < images.Length; i++)
            {
                images[i].SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            for (int i = 0; i < images.Length; i++)
            {
                images[i].SetActive(false);
            }
        }
    }
}
