using System.Collections;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] AudioClip breakSFX;
    AudioSource _aud;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {

            StartCoroutine(Des());
        }
    }
    IEnumerator Des()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        _aud = GetComponent<AudioSource>();
        _aud.PlayOneShot(breakSFX);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
