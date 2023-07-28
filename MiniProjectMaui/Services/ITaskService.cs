using MiniProjectMaui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMaui.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetFilteredTasks(string filterText);
        Task<IEnumerable<TaskModel>> GetSortedTasks(string sortText);
        Task<IEnumerable<TaskModel>> GetTasks();
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task);
        Task<TaskModel> DeleteTask(int id);
    }
}


