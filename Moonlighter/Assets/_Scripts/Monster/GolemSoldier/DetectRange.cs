using UnityEngine;

public class DetectRange : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = gameObject.transform.root.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagLiteral.PLAYER))
        {
            _anim.SetTrigger(MonsterAnimParams.TRACING);
        }
    }
}
