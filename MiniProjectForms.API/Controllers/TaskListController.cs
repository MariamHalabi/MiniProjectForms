﻿using Microsoft.AspNetCore.Mvc;
using MiniProjectForms.Data;
using MiniProjectForms.Models;
using System.Linq;

namespace MiniProjectForms.API.Controllers
{
    [ApiController]
    [Route("api/TaskList")]
    public class TaskListController : ControllerBase
    {
        private readonly MiniProjectFormsContext _dbContext;

        public TaskListController(MiniProjectFormsContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<TaskModel> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }

        [HttpGet("Device/{device}")]
        public IEnumerable<TaskModel> GetAllByDevice(string device)
        {
            return _dbContext.Tasks.Where(t => t.DeviceId == device).ToList();
        }

        [HttpGet("{id}")]
        public TaskModel GetTask(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(t => t.Id == id)!;
        }

        [HttpPost]
        public TaskModel AddTask(TaskModel task)
        {
            var addedTask = _dbContext.Tasks.Add(task).Entity;
            _dbContext.SaveChanges();

            return addedTask;
        }

        [HttpPut]
        public TaskModel UpdateTask(TaskModel task)
        {
            var taskToUpdate = _dbContext.Tasks.FirstOrDefault(t => t.Id == task.Id);

            if(taskToUpdate != null)
            {
                taskToUpdate.Title = task.Title;
                taskToUpdate.Description = task.Description;
                taskToUpdate.IsCompleted = task.IsCompleted;
                taskToUpdate.DueDate = task.DueDate;
            }

            _dbContext.SaveChanges();

            var updatedTask = _dbContext.Tasks.FirstOrDefault(t => t.Id == task.Id)!;
            return updatedTask;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            _dbContext.Tasks.Remove(taskToDelete);
            _dbContext.SaveChanges();

            return Ok(taskToDelete);
        }

        [HttpGet("Filtered/{filterText}")]
        public IEnumerable<TaskModel> GetFilteredTasks(string filterText)
        {
            return _dbContext.Tasks.Where(t => t.Title.Contains(filterText)).ToList();
        }

        [HttpGet("Sorted/{sortText}")]
        public IEnumerable<TaskModel> GetSortedTasks(string sortText)
        {
            List<TaskModel> tasks;

            switch(sortText)
            {
                case "Title":
                     tasks = _dbContext.Tasks.GroupBy(t => t.Title).AsEnumerable().SelectMany(g => g).ToList();
                    break;

                case "Due Date":
                    tasks = _dbContext.Tasks.GroupBy(t => t.DueDate).AsEnumerable().SelectMany(g => g).ToList();
                    break;

                default: tasks = _dbContext.Tasks.ToList(); break;
            }

            return tasks;   
        }
    }
}


