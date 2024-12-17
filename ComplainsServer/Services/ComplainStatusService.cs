using Base;
using BaseServer;

namespace ComplainsServer;

public class ComplainStatusService : BaseService<ComplainStatus> , IComplainStatusService
{
    public ComplainStatusService(MigrationsDbContext context) : base(context)
    {
    }
}
