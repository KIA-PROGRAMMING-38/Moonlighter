using UnityEngine;
using EnumValue;

public class Player : MonoBehaviour
{
    private Animator _anim;
    [SerializeField]
    private PlayerData _playerData;

    public PlayerStates CurrentState { get; set; }
    public PlayerStates PrevState { get; set; }

    public PlayerData PlayerData
    {
        get
        {
            return _playerData;
        }
    }

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _anim.SetBool("Idle", true);
    }
}
