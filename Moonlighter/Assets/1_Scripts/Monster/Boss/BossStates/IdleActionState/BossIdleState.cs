using UnityEngine;
using EnumValue;

public class BossIdleState : BossIdleActionState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animHandler.IsAnimationEnded)
        {
            BossAttackAction nextAction = boss.bossAttackState.Dequeue();
            animHandler.ResetAnimationState();

            switch(nextAction)
            {
                case BossAttackAction.Wave:
                    boss.bossAttackState.Enqueue(BossAttackAction.Wave);
                    animator.SetTrigger(MonsterAnimParams.WAVE);
                    break;
                case BossAttackAction.StoneArmPunch:
                    boss.bossAttackState.Enqueue(BossAttackAction.StoneArmPunch);
                    animator.SetTrigger(MonsterAnimParams.STONEARMPUNCHTRIGGER);
                    break;
                case BossAttackAction.StoneArmStamp:
                    boss.bossAttackState.Enqueue(BossAttackAction.StoneArmStamp);
                    animator.SetTrigger(MonsterAnimParams.STONEARMROCKSTAMPTRIGGER);
                    break;
                case BossAttackAction.StickyArmAction:
                    boss.bossAttackState.Enqueue(BossAttackAction.StickyArmAction);
                    animator.SetTrigger(MonsterAnimParams.STICKYARMACTIONTRIGGER);
                    break;
            }
        }
    }
}
