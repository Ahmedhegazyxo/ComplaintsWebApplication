using Base;
using BaseServer;

namespace ComplainsServer;

public class AttachmentService : BaseService<Attachment>, IAttachmentService
{
    public AttachmentService(MigrationsDbContext context) : base(context)
    {
    }
}
