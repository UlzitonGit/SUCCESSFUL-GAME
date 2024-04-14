using UnityEngine;

public class PlayerMovementDescription : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    PlayerMovement pl;
    PlayerHealth plh;

    [SerializeField] public PlayerMovementDescription otherForm;
    [SerializeField] public GameObject myGhost;
    [SerializeField] ParticleSystem soulPart;
    public string id;

    private void Awake()
    {
        plh = GetComponentInParent<PlayerHealth>();
        pl = GetComponentInParent<PlayerMovement>();
        pl.speed = speed;
        pl.jumpingPower = jumpSpeed;
    }
    public void FirtsIteration()
    {      
        if(FindObjectOfType<GhostEvil>() == null && FindObjectOfType<GhostFriendly>() == null)
        {
            Instantiate(otherForm.myGhost, transform.position, transform.rotation);
        }
       
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            otherForm.gameObject.SetActive(true);
                        
            Instantiate(myGhost, transform.position, transform.rotation);
            otherForm.ChangeParameters();
            gameObject.SetActive(false);
           
        }
    }
    public void ChangeParameters()
    {
        pl.speed = speed;
        pl.jumpingPower = jumpSpeed;
        if (id == "evil")
        {
            pl.transform.position = FindObjectOfType<GhostEvil>().transform.position;
            Destroy(FindObjectOfType<GhostEvil>().gameObject);
            FindObjectOfType<PlayerAttack>().isEvil = true;
        }

        if (id == "friendly")
        {
            
            pl.transform.position = FindObjectOfType<GhostFriendly>().transform.position;
            Destroy(FindObjectOfType<GhostFriendly>().gameObject);
            FindObjectOfType<PlayerAttack>().isEvil = false;
            plh.StartHealing();
        }

        soulPart.Play();
    }
}
