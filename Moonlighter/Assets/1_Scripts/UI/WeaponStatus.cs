using UnityEngine;
using UnityEngine.UI;

public class WeaponStatus : MonoBehaviour
{
    public Image PrimaryWeapon;
    public Image SecondaryWeapon;
    public Image WeaponNumOne;
    public Image WeaponNumTwo;

    private void Awake()
    {
        WeaponPresenter.OnChangeWeapon -= SwapWeaponIcon;
        WeaponPresenter.OnChangeWeapon += SwapWeaponIcon;
    }

    private void SwapWeaponIcon()
    {
        Sprite TmpWeapon = PrimaryWeapon.sprite;
        PrimaryWeapon.sprite = SecondaryWeapon.sprite;
        SecondaryWeapon.sprite = TmpWeapon;

        Sprite TmpNum = WeaponNumOne.sprite;
        WeaponNumOne.sprite = WeaponNumTwo.sprite;
        WeaponNumTwo.sprite = TmpNum;
    }
}
