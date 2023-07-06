using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

public class EffectController : MonoBehaviour
{
    public ObjectPool<GameObject> Pool;

    #region MoveEffect Variables
    private Vector3 _moveEffectScale = new Vector3(0.3f, 0.3f, 1);
    private Vector3 _moveEffeectRotation = new Vector3(0, 0, -90);
    #endregion

    private void DeactiveEffect()
    {
        Pool.Release(this.gameObject);
        this.gameObject.SetActive(false);
    }

    private void SetMoveEffect()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.DOFade(0.5f, 0.3f);

        this.transform.localScale = _moveEffectScale;
        this.transform.rotation = Quaternion.Euler(_moveEffeectRotation);
    }

    private void SetRollEffect(float ZAixsRotation)
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.DOFade(0, 0.6f);

        int rollEffectIndex = Random.Range(0, 4);
        Animator anim = this.GetComponent<Animator>();
        anim.Play($"RollEffect{rollEffectIndex}");

        this.transform.DOLocalRotate(new Vector3(0, 0, ZAixsRotation), 0.6f);
    }

}