using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public static CameraFollowController instance;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float lerpValue;

    private Vector3 offset;
    private Vector3 newPosition;

    void Start()
    {
        offset = transform.position - playerTransform.position;
        instance = this;
    }

    void LateUpdate()
    {
        SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        newPosition = Vector3.Lerp(transform.position, new Vector3(0f, playerTransform.position.y, playerTransform.position.z) + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
