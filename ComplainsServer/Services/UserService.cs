using Base;
using BaseServer;

namespace ComplainsServer;
public class UserService : BaseService<User>, IUserService
{
    public UserService(MigrationsDbContext context) : base(context)
    {
    }
}