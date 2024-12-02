using users.Models;

namespace users.Repositoreis
{
    public class ChangesRepositoreis:IChangesRepositoreis
    {
        private readonly UsersContext _context;

        public ChangesRepositoreis(UsersContext context)
        {
            _context = context;
        }

        public void Add(Models.Change Achange)
        {
            _context.Changes.Add(Achange);
            _context.SaveChanges();
        }
    }
}
