namespace Base;

public class Complain : BaseEntity
{
    public string Name { get; set; }
    public string MilitaryNumber { get; set; }
    public string NationalId { get; set; }
    public string NativeUnit { get; set; }
    public string CurrentUnit { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SecondaryPhoneNumber { get; set; }
    public string? ComplainBody { get; set; }
    public string? ComplainReply { get; set; }
    public int? ComplainStatusId { get; set; }
    public ComplainStatus? ComplainStatus { get; set; }
    public int? ComplainTypeId { get; set; }
    public ComplainType? ComplainType { get; set; }
    public int MilitaryRankId { get; set; }
    public MilitaryRank? MilitaryRank { get; set; }
    public List<ComplainAttachment>? ComplainAttachments { get; set; }
}
