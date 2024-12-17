using Base;
using BaseServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComplainsServer;

public class ComplainController : BaseController<Complain>
{
    IComplainService _service;
    public ComplainController(IComplainService service) : base(service)
    {
        _service = service;
    }
    [HttpGet("GetById/GetWithAllIncludes/{id}")]
    public async Task<Complain> GetByIdWithAllIncludes(int id)
    {
        try
        {
            return await _service.GetComplainByIdWithAllIncludes(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    [HttpPost("Search")]
    public async Task<Complain> Search([FromBody]ComplainSearchModel searchModel )
    {
        try
        {
            Complain complain =  await _service.InquireAboutComplain(searchModel);
            return complain;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    [HttpGet("GetIPAddress")]
    public async Task<string> GetClientIPAddress()
    {
        var forwardedHeaders = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if(!string.IsNullOrEmpty(forwardedHeaders))
        {
            return forwardedHeaders.Split(",").FirstOrDefault();
        }
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        return ipAddress;
    }
}
