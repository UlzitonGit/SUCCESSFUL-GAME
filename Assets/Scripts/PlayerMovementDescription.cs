using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDescription : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] public PlayerMovementDescription otherForm;
    [SerializeField] public GameObject myGhost;
    public string id;
    PlayerMovement pl;

    private void Awake()
    {      
        if(FindObjectOfType<GhostEvil>() == null && FindObjectOfType<GhostFriendly>() == null)
        {
            Instantiate(otherForm.myGhost, transform.position, transform.rotation);
        }
       
    }
    // Update is called once per frame
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
        pl = GetComponentInParent<PlayerMovement>();
        pl.speed = speed;
        pl.jumpingPower = jumpSpeed;
        if (id == "evil")
        {
            pl.transform.position = FindObjectOfType<GhostEvil>().transform.position;
            Destroy(FindObjectOfType<GhostEvil>().gameObject);
        }
        if (id == "friendly")
        {
            pl.transform.position = FindObjectOfType<GhostFriendly>().transform.position;
            Destroy(FindObjectOfType<GhostFriendly>().gameObject);
        }
        
      
    }
}
