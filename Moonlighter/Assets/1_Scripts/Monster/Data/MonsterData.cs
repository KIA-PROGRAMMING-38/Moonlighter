using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/Monster Data/Base Data")]
public class MonsterData : ScriptableObject
{
    public int Maxhp;
    public int CurHp;

    public int NormalDamage;
}
