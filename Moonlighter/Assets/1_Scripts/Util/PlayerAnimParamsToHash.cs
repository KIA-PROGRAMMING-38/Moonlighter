using UnityEngine;

public class PlayerAnimParamsToHash
{
    public static readonly int MOVEX = Animator.StringToHash(PlayerAnimParams.MOVEX);
    public static readonly int MOVEY = Animator.StringToHash(PlayerAnimParams.MOVEY);
    public static readonly int IDLE = Animator.StringToHash(PlayerAnimParams.IDLE);
    public static readonly int MOVE = Animator.StringToHash(PlayerAnimParams.MOVE);
    public static readonly int ROLL = Animator.StringToHash(PlayerAnimParams.ROLL);
    public static readonly int COMBOATTACKONE = Animator.StringToHash(PlayerAnimParams.COMBOATTACKONE);
    public static readonly int COMBOATTACKTWO = Animator.StringToHash(PlayerAnimParams.COMBOATTACKTWO);
    public static readonly int COMBOATTACKTHREE = Animator.StringToHash(PlayerAnimParams.COMBOATTACKTHREE);
    public static readonly int READYSECONDARYACTION = Animator.StringToHash(PlayerAnimParams.READYSECONDARYACTION);
    public static readonly int ONSECONDARYACTION = Animator.StringToHash(PlayerAnimParams.ONSECONDARYACTION);
    public static readonly int SECONDARYACTION = Animator.StringToHash(PlayerAnimParams.SECONDARYACTION);
}
