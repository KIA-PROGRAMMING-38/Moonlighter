using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;

public class DataManager
{
    private readonly string CharacterStatDataCsv = "Assets\\Data\\CharacterStatDataTable.csv";
    private readonly string EffectDataCsv = "Assets\\Data\\EffectDataTable.csv";

    public Dictionary<int, CharacterStatData> CharacterStatDataTable { get; private set; }
    public Dictionary<int, EffectData> EffectDataTable { get; private set; }

    public void Init()
    {
        CharacterStatDataTable = ParseToDict<int, CharacterStatData>(CharacterStatDataCsv, data => data.Id);
        EffectDataTable = ParseToDict<int, EffectData>(EffectDataCsv, data => data.Id);
    }

    public List<T> ParseToList<T>([NotNull] string path)
    {
        using (var reader = new StreamReader(path))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }

    public Dictionary<Key, Item> ParseToDict<Key, Item>([NotNull] string path, Func<Item, Key> keySelector)
    {
        using (var reader = new StreamReader(path))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Item>().ToDictionary(keySelector);
            }
        }
    }
}
