using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    [SerializeField] private int CameraOffsetFollow = 5;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.z = Target.position.z - CameraOffsetFollow;
        transform.position = transformPosition;
    }
}
