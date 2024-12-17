using Base;
using BaseServer;

namespace ComplainsServer;

public class ComplainStatusController : BaseController<ComplainStatus>
{
    private readonly IComplainStatusService _service;
    public ComplainStatusController(IComplainStatusService service) : base(service)
    {
        _service = service;
    }
}
