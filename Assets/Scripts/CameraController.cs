using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed;
    private Vector3 pos;
    void Awake()
    {
        if (!player)
            player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.position;
        pos.z = -10;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * cameraSpeed);
    }
}
