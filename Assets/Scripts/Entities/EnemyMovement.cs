using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 3;
    
    [SerializeField] Transform  point1;
    [SerializeField] Transform point2;
    public int point = 0;

    #region Unused
    bool canSwitchPoint = true;
    bool isRaged = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void FixedUpdate()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        if (Mathf.Abs(distanceFromPlayer) < 15) Chaising(distanceFromPlayer);
        else Finding();
    }
    private void Chaising(float distanceFromPlayer)
    {
        if (distanceFromPlayer < 0) distanceFromPlayer = -1;
        if (distanceFromPlayer > 0) distanceFromPlayer = 1;
        rb.velocity = new Vector2(distanceFromPlayer * speed, rb.velocity.y);
    }
    private void Finding()
    {
        float distanceFromPoint = 0;
        if (point > 1) point = 0; 
        if(point == 0)  distanceFromPoint = point1.position.x - transform.position.x;
        if (point == 1)  distanceFromPoint = point2.position.x - transform.position.x;
        if (point == 0 && Mathf.Abs(distanceFromPoint) <= 0.5)
        {
            point = 1;
            return;
        }

        if (point == 1 && Mathf.Abs(distanceFromPoint) <= 0.5)
        {
            point = 0;
            return;
        }

        if (distanceFromPoint < 0) distanceFromPoint = -1;
        if (distanceFromPoint > 0) distanceFromPoint = 1;
        rb.velocity = new Vector2(distanceFromPoint * speed, rb.velocity.y);
    }
    
}
