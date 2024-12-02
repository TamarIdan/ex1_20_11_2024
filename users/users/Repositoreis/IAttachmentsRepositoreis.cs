using System.Data;
using users.Models;

namespace users.Repositoreis
{
    public interface IAttachmentsRepositoreis
    {
        //DataTable Create(Attachment attachment, Models.Task task);
        DataTable CreateAttachments(string name, string path, string dateUplode);

        public bool ProcessTransaction(Attachment attachment, Models.Task task);
    }
}
