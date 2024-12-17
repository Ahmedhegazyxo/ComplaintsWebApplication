using Base;
using BaseServer;

namespace ComplainsServer;

public class ComplainTypeController : BaseController<ComplainType>
{
    private readonly IComplainTypeService _service;
    public ComplainTypeController(IComplainTypeService service) : base(service)
    {
        _service = service;
    }
}
