using System.Data;
using users.Models;
using users.Repositoreis;

namespace users.Services
{
    public class AttachmentsServices : IAttachmentsServices
    {
        private readonly IAttachmentsRepositoreis _attachmentsRepository;

        public AttachmentsServices(IAttachmentsRepositoreis attachmentsRepository)
        {
            _attachmentsRepository = attachmentsRepository;
        }

        public DataTable CreateAttachment(string name, string path, string dateUplode)
        {
            return _attachmentsRepository.CreateAttachments(name, path, dateUplode);
        }

        public bool Create(AttachmentWithTask model)
        {
            return _attachmentsRepository.ProcessTransaction(model.Attachment, model.Task);
        }
    }
}
