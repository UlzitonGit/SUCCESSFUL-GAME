using Unity.VisualScripting;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] Transform lowwerPoint;
    [SerializeField] Transform higherPoint;
    public bool up;
    [SerializeField] AudioSource _aud;
    [SerializeField] AudioClip _audClip;
    bool canPlaySound = true;
    public bool horizontal = false;
    void Update()
    {
        if (up == false)
        {
            transform.position = Vector3.Lerp(transform.position, lowwerPoint.position, Time.deltaTime);
            
        }

        if (up == true)
        {
            transform.position = Vector3.Lerp(transform.position, higherPoint.position, Time.deltaTime);
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() == null) collision.transform.parent = transform;


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() == null) collision.transform.parent = null;
    }
    public void PlaySound()
    {
        if (canPlaySound == false) return;
        _aud.PlayOneShot(_audClip);
        canPlaySound = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Up") && up == true)
        {
            canPlaySound = true;
            _aud.Stop();
            if (horizontal == false) FindObjectOfType<PlayerMovement>().transform.parent = null;
        }
        if (collision.CompareTag("Low") && up == false)
        {
            canPlaySound = true;
            if(horizontal == false) FindObjectOfType<PlayerMovement>().transform.parent = null;
            _aud.Stop();
        }
    }
}
