using Cinemachine;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Player PlayerRef;

    public float lowerBound;
    public float leftBound;
    public float rightBound;
    public float upperBound;

    public CinemachineVirtualCamera VirtualCamera;

    public Transform InitPosition;

    private void Start()
    {
        VirtualCamera.transform.position = InitPosition.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 tmp = PlayerRef.transform.position;

        if(tmp.x < leftBound)
        {
            tmp.x = leftBound;
        }
        if(tmp.x > rightBound)
        {
            tmp.x = rightBound;
        }
        if(tmp.y > upperBound)
        {
            tmp.y = upperBound;
        }
        if(tmp.y < lowerBound)
        {
            tmp.y = lowerBound;
        }

        tmp.z = -10f;

        VirtualCamera.transform.position = tmp;
    }
}
