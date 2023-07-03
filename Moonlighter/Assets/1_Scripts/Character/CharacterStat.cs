using CsvHelper.Configuration.Attributes;

public class CharacterStat
{
    [Name("Name")]
    public string Name { get; set; }
    [Name("MaxHp")]
    public int MaxHp { get; set; }
    [Name("Atk")]
    public int Atk { get; set; }
    [Name("Def")]
    public int Def { get; set; }
    [Name("MoveSpeed")]
    public float MoveSpeed { get; set; }
    [Name("RollSpeed")]
    public float RollSpeed { get; set; }
}