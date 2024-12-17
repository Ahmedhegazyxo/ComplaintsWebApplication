using Base;
using Microsoft.AspNetCore.Mvc;

namespace BaseServer;

[ApiController]
[Route("api/[controller]/")]
public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
{
    private readonly IBaseService<TEntity> _baseService;
    public BaseController(IBaseService<TEntity> baseService)
    {
        _baseService = baseService;
    }
    [HttpGet("GetById/{id}")]
    public virtual async Task<TEntity> GetById(int id)
    {
        try
        {
            return await _baseService.ReadById(id);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    [HttpGet("GetAllWithCustomIncludes/{customIncludes}")]
    public async Task<List<TEntity>> GetAllWithCustomIncludes(string customIncludes)
    {
        try
        {
            return await _baseService.ReadAllWithCustomIncludes(customIncludes);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    [HttpGet]
    public async Task<List<TEntity>> GetAll()
    {
        try
        {
            return await _baseService.Read();
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    [HttpGet("GetByPredicate")]
    [HttpPost]
    public async Task<TEntity> Add([FromBody] TEntity entity)
    {
        try
        {
            entity.CreatorIPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            return await _baseService.Create(entity);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    [HttpPost("CreateBulk")]
    public async Task<List<TEntity>> AddBulk([FromBody] List<TEntity> entities)
    {
        try
        {
           return await _baseService.CreateBulk(entities);
        }
        catch(Exception exception)
        {
            throw exception;
        }
    }

    [HttpPut]
    public async Task<TEntity> Edit([FromBody] TEntity entity)
    {
        try
        {
            entity.CreatorIPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            return await _baseService.Update(entity);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    [HttpDelete]
    public async Task Delete(TEntity entity)
    {
        try
        {
            await _baseService.Delete(entity);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}
