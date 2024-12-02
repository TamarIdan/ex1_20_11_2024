using Microsoft.AspNetCore.Mvc;
using users.Services;

namespace users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectServices _projectsServices;
        private readonly ITasksServices _tasksServices;

        public ProjectsController(IProjectServices projectsServices, ITasksServices tasksServices)
        {
            _projectsServices = projectsServices;
            _tasksServices = tasksServices;
        }

        [HttpPost("{id}")]
        public IActionResult Create(Models.Task task, int id)
        {

            var project = _projectsServices.GetProjectById(id);

            if (project == null)
            {
                return NotFound("Project not found");
            }

            _tasksServices.AddTask(task);
            project.TaskId = task.Id;
            _projectsServices.UpdateProject(project);

            return Ok(project);
        }
    }
}
