using users.Models;

namespace users.Services
{
    public interface IProjectServices
    {
        Project GetProjectById(int id);

        void UpdateProject(Project project);
    }
}
