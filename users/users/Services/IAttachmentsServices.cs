using System.Data;
using users.Models;

namespace users.Services
{
    public interface IAttachmentsServices
    {
        DataTable CreateAttachment(string name, string path, string dateUplode);
        bool Create(AttachmentWithTask model);
    }
}
