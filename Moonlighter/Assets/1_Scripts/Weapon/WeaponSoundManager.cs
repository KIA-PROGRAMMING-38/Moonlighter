using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSoundManager : MonoBehaviour
{
    public AudioSource AudioSource;

    public AudioClip BigSwordComboAttackOneSound;
    public AudioClip BigSwordComboAttackTwoSound;
    public AudioClip BigSwordComboAttackThreeSound;
    public AudioClip BigSwordSecondaryAttackSound;

    public AudioClip SnSComboAttackOneSound;
    public AudioClip SnSComboAttackTwoSound;
    public AudioClip SnSComboAttackThreeSound;
    public AudioClip SnsShieldOn;

    #region BigSword

    void PlayBSComboAttackOne()
    {
        AudioSource.PlayOneShot(BigSwordComboAttackOneSound);
    }

    void PlayBSComboAttackTwo()
    {
        AudioSource.PlayOneShot(BigSwordComboAttackTwoSound);
    }

    void PlayBSComboAttackThree()
    {
        AudioSource.PlayOneShot(BigSwordComboAttackThreeSound);
    }

    void PlayBSSecondaryAttack()
    {
        AudioSource.PlayOneShot(BigSwordSecondaryAttackSound);
    }

    #endregion

    #region SnS

    void PlaySnSComboAttackOne()
    {
        AudioSource.PlayOneShot(SnSComboAttackOneSound);
    }

    void PlaySnSComboAttackTwo()
    {
        AudioSource.PlayOneShot(SnSComboAttackTwoSound);
    }

    void PlaySnSComboAttackThree()
    {
        AudioSource.PlayOneShot(SnSComboAttackThreeSound);
    }

    void PlaySnSShieldOn()
    {
        AudioSource.PlayOneShot(SnsShieldOn);
    }

    #endregion
}
