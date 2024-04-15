using System.Collections;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;
    public bool isInteracted = false;
    AudioSource _aud;
    [SerializeField] AudioClip _audClip;
    public void UseBridge()
    {
        if (isInteracted == true) return;
        _aud = GetComponent<AudioSource>();
        _aud.PlayOneShot(_audClip);
        anim.SetTrigger("Use");
        anim2.SetTrigger("Use");
        isInteracted = true;
        StartCoroutine(AudPlay());
    }
    IEnumerator AudPlay()
    {
        yield return new WaitForSeconds(1);
        _aud.Stop();
    }
}
