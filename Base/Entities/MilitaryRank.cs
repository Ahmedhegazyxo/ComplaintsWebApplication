namespace Base;

public class MilitaryRank : BaseEntity
{
    public int RankPriority { get; set; }
    public string Name { get; set; }
    public RankType RankType { get; set; }
}
