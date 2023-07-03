using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class DataManager
{
    private string CharacterStatCsv = "Assets\\Data\\CharacterStatDataTable.csv";

    public Dictionary<string, CharacterStat> CharacterStatDataTable = new Dictionary<string, CharacterStat>();

    public void Init()
    {
        ParsingCharacterStatCSV(CharacterStatCsv);
    }

    private void ParsingCharacterStatCSV(string path)
    {
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<CharacterStat>();
            foreach (var record in records)
            {
                CharacterStatDataTable.Add(record.Name, record);
            }
        }
    }
}
