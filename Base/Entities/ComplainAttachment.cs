namespace Base;

public class ComplainAttachment : BaseEntity
{
    public int AttachmentId { get; set; }
    public int ComplainId { get; set; }
    public Attachment? Attachment { get; set; }
}
