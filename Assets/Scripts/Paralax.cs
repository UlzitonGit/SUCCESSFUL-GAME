using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float lenghr, startpos;
    public GameObject cam;
    public float parallacEffect;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        //lenghr = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1- parallacEffect));
        float dist = (cam.transform.position.x * parallacEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (temp > startpos + lenghr) startpos += lenghr;
        else if(temp < startpos - lenghr) startpos -= lenghr;
    }
}
