using users.Models;

namespace users.Repositoreis
{
    public interface IProjectRepositoreis
    {
        Project GetById(int id);
        void Update(Project project);

    }
}
