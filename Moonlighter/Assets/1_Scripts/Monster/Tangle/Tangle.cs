using UnityEngine;

public class Tangle : Monster
{
    public bool IsCollision { get; private set; }

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
