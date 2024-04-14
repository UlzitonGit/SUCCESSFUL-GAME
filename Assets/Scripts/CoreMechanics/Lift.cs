using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] Transform lowwerPoint;
    [SerializeField] Transform higherPoint;
    public bool up;

    void Update()
    {
        if(up == false) transform.position = Vector3.Lerp(transform.position, lowwerPoint.position, Time.deltaTime);
        if (up == true) transform.position = Vector3.Lerp(transform.position, higherPoint.position, Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() == null) collision.transform.parent = transform;


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() == null) collision.transform.parent = null;
    }
}
