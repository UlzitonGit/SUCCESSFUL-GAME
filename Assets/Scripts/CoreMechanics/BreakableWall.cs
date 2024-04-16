using System.Collections;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] AudioClip breakSFX;
    [SerializeField] ParticleSystem part;
    AudioSource _aud;
    [SerializeField] SpriteRenderer _spriteRenderer;
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
        _spriteRenderer.enabled = false;
        part.Play();
        _aud = GetComponent<AudioSource>();
        _aud.PlayOneShot(breakSFX);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
