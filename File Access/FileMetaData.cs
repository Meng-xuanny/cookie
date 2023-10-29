public class FileMetaData
{
    public string Name { get; }
    public FileFormat Format { get; }

    public FileMetaData(string fileName, FileFormat format)
    {
        Name = fileName;
        Format = format;
    }

    public string ToPath() => $"{Name}.{Format.AsFileExtension()}";
}
