namespace Base;

public class Attachment : BaseEntity
{
    public string AttachmentAttribute { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public byte[]? Content { get; set; }
}
