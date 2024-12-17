using Base;
using BaseServer;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace ComplainsServer;

public class ComplainService : BaseService<Complain>, IComplainService
{
    MigrationsDbContext _context;
    IAttachmentService _attachmentService;
    public ComplainService(MigrationsDbContext context) : base(context)
    {
        _context = context;
        _attachmentService = new AttachmentService(context);
    }
    public override async Task<Complain> Create(Complain entity)
    {
        var transaction = _context.Database.BeginTransaction();
        try
        {

            List<ComplainAttachment>? complainAttachments = new List<ComplainAttachment>();
            List<Attachment>? attachments = new List<Attachment>();
            complainAttachments = entity.ComplainAttachments;
            entity.ComplainAttachments = null;
            Complain complain = await base.Create(entity);
            if (complainAttachments is not null && complainAttachments.Count() != 0)
            {
                foreach (ComplainAttachment complainAttachment in complainAttachments)
                {
                    attachments.Add(new Attachment
                    {
                        Content = complainAttachment.Attachment.Content,
                        FileType = complainAttachment.Attachment.FileType,
                        FileName = complainAttachment.Attachment.FileName,
                        AttachmentAttribute = complainAttachment.Attachment.AttachmentAttribute
                    });
                }
                attachments = await _attachmentService.CreateBulk(attachments, transaction);
                foreach (Attachment attachment in attachments)
                {
                    await _context.Set<ComplainAttachment>().AddAsync(new ComplainAttachment
                    {
                        ComplainId = complain.Id,
                        AttachmentId = attachment.Id,
                        Attachment = null
                    });
                }
            }
            if (transaction is not null) 
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                
            }
            else
                await transaction.RollbackAsync();
            return complain;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Complain was not created");
        }

    }

    public async Task<Complain> GetComplainByIdWithAllIncludes(int id)
    {
        try
        {
            return await _context.Set<Complain>().Include(e => e.ComplainAttachments).ThenInclude(e => e.Attachment).FirstOrDefaultAsync(e => e.Id == id);
        }
        catch(Exception exception)
        {
            throw new Exception("Error while reading the entity");
        }
    }

    public async Task<Complain> InquireAboutComplain(ComplainSearchModel searchModel)
    {
        try
        {
            return await _context.Set<Complain>().Include(e=>e.ComplainAttachments).ThenInclude(e=>e.Attachment).FirstAsync(e => e.NationalId == searchModel.NationalId && e.Id == searchModel.ComplainId && e.MilitaryNumber == searchModel.MilitaryNumber);
        }
        catch
        {
            throw new Exception("No Complain Was Found");
        }
    }
}
