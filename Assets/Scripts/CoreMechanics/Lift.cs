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
}
