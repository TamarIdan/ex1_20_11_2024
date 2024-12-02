using users.Models;
using users.Repositoreis;

namespace users.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepositoreis _projectsRepository;

        public ProjectServices(IProjectRepositoreis projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public Project GetProjectById(int id)
        {
            return _projectsRepository.GetById(id);
        }

        public void UpdateProject(Project project)
        {
            _projectsRepository.Update(project);
        }
    }
}
