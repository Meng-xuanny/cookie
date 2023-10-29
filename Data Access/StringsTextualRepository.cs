
/// <summary>
/// implementation--txt
/// </summary>
public class StringsTextualRepository : StringsRepository
{
    private static readonly string _separator = Environment.NewLine;

    protected override List<string> TextToString(string fileContents)=>fileContents.Split(_separator).ToList(); 

    protected override string StringToText(List<string> strings)=> string.Join(_separator, strings);

}
