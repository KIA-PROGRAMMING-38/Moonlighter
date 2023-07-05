using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class DataManager
{
    private string CharacterStatCsv = "Assets\\Data\\CharacterStatDataTable.csv";

    public Dictionary<int, CharacterStat> CharacterStatDataTable = new Dictionary<int, CharacterStat>();

    public void Init()
    {
        Parsing(CharacterStatCsv, CharacterStatDataTable);
    }

    public void Parsing<T>(string path, Dictionary<int, T> dic) where T : Data
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
