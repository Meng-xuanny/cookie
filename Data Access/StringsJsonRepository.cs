using System.Text.Json;
/// <summary>
/// implementation--json
/// </summary>
public class StringsJsonRepository : StringsRepository
{
    protected override List<string> TextToString(string fileContents) => JsonSerializer.Deserialize<List<string>>(fileContents);

    protected override string StringToText(List<string> strings) => JsonSerializer.Serialize(strings);
}
