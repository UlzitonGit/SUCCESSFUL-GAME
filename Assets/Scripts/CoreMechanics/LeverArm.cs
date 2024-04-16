using System.Collections;
using UnityEngine;


public class LeverArm : MonoBehaviour
{
    [SerializeField] public Lift _lift;
    [SerializeField] Animator anim;
    AudioSource _aud;
    [SerializeField] AudioClip AudioClip;
    bool canBeInteracted = true;
    [SerializeField] Transform trail;
    bool _to = false;
    public void SwitchLift()
    {
        _aud = GetComponent<AudioSource>();
        if (canBeInteracted == false) return;
        if (_lift.up == true)
        {
            _aud.PlayOneShot(AudioClip);
            _lift.up = false;
            _lift.PlaySound();
            StartCoroutine(Reloading());
            anim.SetTrigger("Switch");
            return;
        }
        else
        {
            _aud.PlayOneShot(AudioClip);
            _lift.up = true;
            _lift.PlaySound();
            StartCoroutine(Reloading());
            anim.SetTrigger("Switch");
            return;
        }
    }
    IEnumerator Reloading()
    {
        canBeInteracted = false;
        yield return new WaitForSeconds(1);
        canBeInteracted = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trail.position = Vector3.Lerp(trail.position, _lift.transform.position, Time.deltaTime * 3);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trail.position = transform.position;
        }
    }
}
