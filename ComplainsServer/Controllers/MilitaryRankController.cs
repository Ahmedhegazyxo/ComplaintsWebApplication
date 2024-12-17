using Base;
using BaseServer;

namespace ComplainsServer;

public class MilitaryRankController : BaseController<MilitaryRank>
{
    IMilitaryRankService _service;
    public MilitaryRankController(IMilitaryRankService service) : base(service)
    {
        _service = service;
    }
}
