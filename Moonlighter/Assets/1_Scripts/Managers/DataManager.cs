using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class DataManager
{
    private readonly string CharacterStatDataCsv = "Assets\\Data\\CharacterStatDataTable.csv";
    private readonly string EffectAnimatorControllerDataCsv = "Assets\\Data\\EffectAnimatorControllerDataTable.csv";

    public Dictionary<int, CharacterStatData> CharacterStatDataTable = new Dictionary<int, CharacterStatData>();
    public Dictionary<int, EffectAnimatorControllerData> EffectAnimatorControllerDataTable = new Dictionary<int, EffectAnimatorControllerData>();

    public void Init()
    {
        Parse(CharacterStatDataCsv, CharacterStatDataTable);
        Parse(EffectAnimatorControllerDataCsv, EffectAnimatorControllerDataTable);
    }

    public void Parse<T>(string path, Dictionary<int, T> dic) where T : Data
    {
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<T>();
            foreach (var record in records)
            {
                dic.Add(record.Id, record);
            }
        }
    }

    
}
