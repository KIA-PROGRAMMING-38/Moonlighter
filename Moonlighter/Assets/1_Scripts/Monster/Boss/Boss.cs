using System.Collections.Generic;
using UnityEngine;
using EnumValue;

public class Boss : Monster
{
    public Transform Player { get; private set; }
    public GameObject StoneArmAttack { get; private set; }
    public GameObject RocksGenerator { get; private set; }

    public bool RockStateEnd { get; set; }

    public Queue<BossAttackAction> bossAttackState;

    public AudioClip BossAwakeSound;
    public AudioClip BossDeathSound;

    public override void Awake()
    {
        base.Awake();
        Player = GameObject.FindGameObjectWithTag(ObjectLiteral.PLAYER).transform;
        StoneArmAttack = transform.GetChild(1).gameObject;
        RocksGenerator = transform.GetChild(4).gameObject;
        bossAttackState = new Queue<BossAttackAction>();
        bossAttackState.Enqueue(BossAttackAction.StickyArmAction);
        bossAttackState.Enqueue(BossAttackAction.Wave);
        bossAttackState.Enqueue(BossAttackAction.StoneArmPunch);
        bossAttackState.Enqueue(BossAttackAction.Wave);
        bossAttackState.Enqueue(BossAttackAction.StoneArmStamp);
        bossAttackState.Enqueue(BossAttackAction.Wave);
    }

    private void Update()
    {
        if(IsDie)
        {
            _spriteRenderer.material = _originMaterial;
        }
    }

    private void PlayBossAwakeSound()
    {
        MonsterAudioSource.PlayOneShot(BossAwakeSound);
    }

    private void PlayBossDeathSound()
    {
        MonsterAudioSource.PlayOneShot(BossDeathSound);
    }

    private void ActiveRocksGenerator()
    {
        RocksGenerator.SetActive(true);
    }

    private void RockStateEndTrigger()
    {
        RockStateEnd = true;
    }

    private void InactiveRocksGenerator()
    {
        RocksGenerator.SetActive(false);
    }

    private void ActiveStoneArmStamp()
    {
        StoneArmAttack.SetActive(true);
    }

    private void InactiveStoneArmStamp()
    {
        StoneArmAttack.SetActive(false);
    }

}
