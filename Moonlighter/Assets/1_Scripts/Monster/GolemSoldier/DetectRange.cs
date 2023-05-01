using UnityEngine;

public class DetectRange : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = gameObject.transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagLiteral.PLAYER))
        {
            this.gameObject.SetActive(false);
            _anim.SetTrigger(MonsterAnimParams.TRACING);
        }
    }
}
