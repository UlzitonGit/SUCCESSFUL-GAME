using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed;
    private Vector3 pos;

    private Camera cam;
    private float maxZoom = 5f;
    private float minZoom = 10f;
    private float sensitivity = 1f;
    private float speed = 30f;
    private float targetZoom;
    public bool folow = false;
    void Awake()
    {
        cam = GetComponent<Camera>();
        targetZoom = cam.orthographicSize;

        if (!player) player = FindObjectOfType<PlayerMovement>().transform;
       
    }
   
    public void teleport()
    {
      
        StartCoroutine(Show());

    }
    void Update()
    {
        
        pos = player.position;
        pos.z = -10;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * cameraSpeed);

        CameraDistance();
    }

    private void CameraDistance()
    {
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speed * Time.deltaTime);
        cam.orthographicSize = newSize;
    }
    IEnumerator Show()
    {
        cameraSpeed = 100f;
        yield return new WaitForSeconds(1);
        cameraSpeed = 2f;
    }
}