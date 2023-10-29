public static class FileExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat) => fileFormat==FileFormat.Json ? "json" : "txt";
}
