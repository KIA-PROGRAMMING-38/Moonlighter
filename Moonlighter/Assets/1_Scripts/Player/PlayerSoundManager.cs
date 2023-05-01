using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioSource AudioSource;

    public AudioClip WalkingSound;
    public AudioClip RollingSound;
    public AudioClip HitSound;
    public AudioClip UsePotionSound;

    void PlayerWalkingSound()
    {
        AudioSource.PlayOneShot(WalkingSound);
    }

    void PlayerRollingSound()
    {
        AudioSource.PlayOneShot(RollingSound);
    }

    public void PlayHitSound()
    {
        AudioSource.PlayOneShot(HitSound);
    }

    public void PlayerUsePotionSound()
    {
        AudioSource.PlayOneShot(UsePotionSound);
    }
}
