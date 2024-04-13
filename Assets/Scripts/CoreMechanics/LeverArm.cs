using System.Collections;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    [SerializeField] public Lift _lift;
    [SerializeField] Animator anim;
    bool canBeInteracted = true;
    public void SwitchLift()
    {
        if (canBeInteracted == false) return;
        if (_lift.up == true)
        {
            _lift.up = false;
            StartCoroutine(Reloading());
            anim.SetBool("Up", false);
            return;
        }
        else
        { 
            _lift.up = true;
            StartCoroutine(Reloading());
            anim.SetBool("Up", true);
            return;
        }
    }
    IEnumerator Reloading()
    {
        canBeInteracted = false;
        yield return new WaitForSeconds(1);
        canBeInteracted = true;
    }
}
