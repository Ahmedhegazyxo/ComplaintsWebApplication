using Base;
using BaseServer;

namespace ComplainsServer;

public class MilitaryRankService : BaseService<MilitaryRank>, IMilitaryRankService
{
    public MilitaryRankService(MigrationsDbContext context) : base(context)
    {
    }
}
