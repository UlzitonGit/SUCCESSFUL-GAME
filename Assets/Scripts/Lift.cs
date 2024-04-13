using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Lift : MonoBehaviour
{
    [SerializeField] Transform lowwerPoint;
    [SerializeField] Transform higherPoint;
    public bool up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(up == false) transform.position = Vector3.Lerp(transform.position, lowwerPoint.position, Time.deltaTime);
        if (up == true) transform.position = Vector3.Lerp(transform.position, higherPoint.position, Time.deltaTime);
    }
}
