using users.Models;

namespace users.Repositoreis
{
    public class ProjectRepositoreis : IProjectRepositoreis
    {
        private readonly UsersContext _context;

        public ProjectRepositoreis(UsersContext context)
        {
            _context = context;
        }

        public Project GetById(int id)
        {
            Project? project = _context.Projects.Find(id);
            return project;
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
