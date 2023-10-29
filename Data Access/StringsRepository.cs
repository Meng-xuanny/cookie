public abstract class StringsRepository : IStringsRepository
{ 
    public List<string> Read(string filepath)
    {
        if (File.Exists(filepath))
        {
            string fileContents = File.ReadAllText(filepath);
            
            return TextToString(fileContents);
        }
        return new List<string>();
    }

    protected abstract List<string> TextToString(string fileContents);
    

    public void Write(string filepath, List<string> strings) =>
        File.WriteAllText(filepath, StringToText(strings));

    protected abstract string StringToText(List<string> strings);

}
