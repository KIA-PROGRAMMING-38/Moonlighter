using UnityEngine;

public class RocketArmBody : MonoBehaviour
{
    public CapsuleCollider2D Collider { get; private set; }

    public GameObject PunchCrack;

    public AudioSource _audioSource;
    public AudioClip StampSound;

    private void Awake()
    {
        Collider = GetComponent<CapsuleCollider2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void PlayPunchStamp()
    {
        _audioSource.PlayOneShot(StampSound);
    }

    private void ActiveRocketArmAttack()
    {
        Collider.enabled = true;
    }

    private void InactiveRocketArmAttack()
    {
        Collider.enabled = false;
    }

    private void CreatePunchCrack()
    {
        Instantiate(PunchCrack, this.transform.parent.position, Quaternion.identity);
    }
}
