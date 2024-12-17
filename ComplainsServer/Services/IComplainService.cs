using Base;
using BaseServer;

namespace ComplainsServer;

public interface IComplainService : IBaseService<Complain>
{
    Task<Complain> GetComplainByIdWithAllIncludes(int id); 
    Task<Complain> InquireAboutComplain(ComplainSearchModel searchModel);
}