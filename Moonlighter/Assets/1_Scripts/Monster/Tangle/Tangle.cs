using UnityEngine;

public class Tangle : Monster
{
    public bool IsCollision { get; private set; }

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagLiteral.PLAYER))
        {
            IsCollision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagLiteral.PLAYER))
        {
            IsCollision = false;
        }
    }
}
