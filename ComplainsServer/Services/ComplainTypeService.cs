using Base;
using BaseServer;

namespace ComplainsServer;

public class ComplainTypeService : BaseService<ComplainType>, IComplainTypeService
{
    public ComplainTypeService(MigrationsDbContext context) : base(context)
    {
    }
}
