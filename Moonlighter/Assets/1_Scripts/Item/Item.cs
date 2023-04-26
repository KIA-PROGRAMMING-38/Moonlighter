using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    protected ItemData itemData;

    [SerializeField]
    protected Vector3 bagIconPos;

    private Vector3 _startPos;
    private Vector3 _midPos;

    private float _moveSpeed = 7.0f; 

    IEnumerator _goToBag;

    private void Awake()
    {
        _goToBag = GoToBag(bagIconPos, _moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(TagLiteral.PLAYER))
        {
            StartCoroutine(_goToBag);
        }
    }

    IEnumerator GoToBag(Vector3 targetPos, float speed)
    {
        float startTime = Time.time;
        _startPos = transform.position;

        // 이동할 거리와 중심점을 계산
        _midPos = new Vector3((_startPos.x + targetPos.x) / 2f, Mathf.Max(_startPos.y, targetPos.y) + 1f, 0);
        float distance = Vector3.Distance(_startPos, targetPos);

        while (transform.position != targetPos)
        {
            // 포물선 곡선 계산
            float timeFraction = (Time.time - startTime) / (distance / speed);
            transform.position = Bezier.Second(_startPos, _midPos, targetPos, timeFraction);

            yield return null;
        }
    }

}
