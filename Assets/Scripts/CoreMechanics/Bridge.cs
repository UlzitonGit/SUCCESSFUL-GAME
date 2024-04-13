using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] Animator anim;
    public bool isInteracted = false;
    public void UseBridge()
    {
        if (isInteracted == true) return;
        anim.SetTrigger("Use");
        isInteracted = true;
    }
}
