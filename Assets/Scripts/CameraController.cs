using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed;
    private Vector3 pos;

    private Camera cam;
    private float maxZoom = 5f;
    private float minZoom = 15f;
    private float sensitivity = 1f;
    private float speed = 30f;
    private float targetZoom;

    void Awake()
    {
        cam = GetComponent<Camera>();
        targetZoom = cam.orthographicSize;

        if (!player) player = FindObjectOfType<PlayerMovement>().transform;
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
}