using CsvHelper.Configuration.Attributes;

public class EffectAnimatorControllerData : Data
{
    [Name("Name")]
    public string EffectName { get; set; }
    [Name("Path")]
    public string AnimatorControllerPath { get; set; }

}
