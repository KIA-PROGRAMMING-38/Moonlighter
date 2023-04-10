using EnumValue;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator Anim { get; set; }
    [SerializeField]
    private PlayerData _playerData;

    public AnimationHandler AnimHandler { get; private set; }

    public PlayerStates CurrentState { get; set; }
    public PlayerStates PrevState { get; set; }

    public Weapons CurrentPrimaryWeapon { get; set; }

    public PlayerData PlayerData
    {
        get
        {
            return _playerData;
        }
    }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        AnimHandler = GetComponent<AnimationHandler>();
        CurrentPrimaryWeapon = Weapons.BigSword;
    }

    private void Start()
    {
        Anim.SetBool("Idle", true);
        
    }
}
