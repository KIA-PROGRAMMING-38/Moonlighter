using System.Collections.Generic;
using UnityEngine;
using EnumValue;

public class Boss : Monster
{
    [SerializeField]
    public Transform Player;
    public GameObject StoneArmAttack { get; private set; }
    public GameObject RocksGenerator { get; private set; }

    public bool RockStateEnd { get; set; }

    public Queue<BossAttackAction> bossAttackState;

    public AudioClip BossAwakeSound;
    public AudioClip BossDeathSound;

    public const int StoneArmNum = 1;
    public const int RocksGeneratorNum = 4;

    public override void Awake()
    {
        base.Awake();
        StoneArmAttack = transform.GetChild(StoneArmNum).gameObject;
        RocksGenerator = transform.GetChild(RocksGeneratorNum).gameObject;
        bossAttackState = new Queue<BossAttackAction>();
        bossAttackState.Enqueue(BossAttackAction.StoneArmPunch);
        bossAttackState.Enqueue(BossAttackAction.Wave);
        bossAttackState.Enqueue(BossAttackAction.StoneArmStamp);
        bossAttackState.Enqueue(BossAttackAction.Wave);
        bossAttackState.Enqueue(BossAttackAction.StickyArmAction);
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
