using UnityEngine;
public class FollowCam : MonoBehaviour
{
    [SerializeField]
    float _followSpeed = 1f;


    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Vector3 _offset;
    
    private void LateUpdate()
    {
        Vector3 targetPos = _target.position + _offset;
        targetPos.z = -10f;
        
        transform.position = targetPos;
    }
}
