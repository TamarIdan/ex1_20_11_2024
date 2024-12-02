using users.Models;
using users.Repositoreis;

namespace users.Services
{
    public class TasksServices : ITasksServices
    {
        private readonly ITasksRepositoreis _tasksRepository;

        public TasksServices(ITasksRepositoreis tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public void AddTask(Models.Task newTask)
        {
            _tasksRepository.Add(newTask);
        }
    }
}
