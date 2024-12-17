using Base;
using BaseServer;

namespace ComplainsServer;

public class UserController : BaseController<User>
{
    private readonly IUserService _userService;
    public UserController(IUserService service) : base(service)
    {
        _userService = service;
    }
}
