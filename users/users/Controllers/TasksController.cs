﻿using Microsoft.AspNetCore.Mvc;
using users.Models;
using users.Services;

namespace users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksServices _tasksServices;
        private readonly IUsersServices _usersServices; 

        public TasksController(ITasksServices tasksServices, IUsersServices usersServices)
        {
            _tasksServices = tasksServices;
            _usersServices = usersServices; 
        }

        [HttpPost]
        public IActionResult Create(Models.Task task, int id)
        {

            var user = _usersServices.GetUserById(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            _tasksServices.AddTask(task);

            user.TaskId = task.Id;
            _usersServices.UpdateUser(user);

            return Ok(user); 
        }
    }
}
