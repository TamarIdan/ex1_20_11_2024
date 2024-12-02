using users.Models;
namespace users.Repositoreis
{
    public interface IUserRepositoreis
    {
        List<User> GetUsers();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        List<Models.Task> GetTasksByUserId(int userId);
        void Add(Models.Task newTask);
    }
}
