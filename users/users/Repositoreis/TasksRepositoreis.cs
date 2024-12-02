using users.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace users.Repositoreis
{
    public class TasksRepositoreis : ITasksRepositoreis
    {
        private readonly UsersContext _context;

        public TasksRepositoreis(UsersContext context)
        {
            _context = context;
        }

        public void Add(Models.Task task)
        {
            _context.Tasks.Add(task);
            Change newchange = new Change();
            newchange.Discription = "task crated";
            newchange.Date = DateOnly.FromDateTime(DateTime.Now);
            _context.Changes.Add(newchange);
            _context.SaveChanges();
        }
    }
}
