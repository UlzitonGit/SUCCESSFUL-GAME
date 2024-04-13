using UnityEngine;

public class PlayerInteractiveItems : MonoBehaviour
{
    [SerializeField] GameObject interactText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bridge"))
        {

            if(collision.GetComponent<Bridge>().isInteracted == false) interactText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                collision.GetComponent<Bridge>().UseBridge();
                interactText.SetActive(false);
            }
        }
        if (collision.CompareTag("Lever arm"))
        {

            interactText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                collision.GetComponent<LeverArm>().SwitchLift();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bridge"))
        {
            interactText.SetActive(false);
        }
        if (collision.CompareTag("Lever arm"))
        {
            interactText.SetActive(false);
        }
    }
}
