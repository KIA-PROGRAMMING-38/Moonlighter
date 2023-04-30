using UnityEngine;
using EnumValue;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/Monster Data/Base Data")]
public class MonsterData : ScriptableObject
{
    public MonsterType MonsterType;

    public int Maxhp;
    public int CurHp;

    public int NormalDamage;
}
