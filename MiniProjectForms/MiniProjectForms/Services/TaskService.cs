using MiniProjectForms.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MiniProjectForms.Services
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient _httpClient;
        private const string _apiClient = "https://63cc-89-108-154-125.ngrok-free.app"; //Depends on Tunnel for localhost

        public TaskService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiClient + "/api/");
        }

        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
            try
            {
                var tasksResponse = await _httpClient.GetAsync("TaskList");
                var tasksModels = await tasksResponse.Content.ReadFromJsonAsync<IEnumerable<TaskModel>>();

                return (tasksModels != null) ? tasksModels : new List<TaskModel>();

            }
            catch (Exception)
            {
                return new List<TaskModel>();
            }

        }

        public async Task<IEnumerable<TaskModel>> GetTasksByDevice()
        {
            try
            {
                var tasksResponse = await _httpClient.GetAsync("TaskList/Device/"+DeviceInfo.Name.ToString());
                var tasksModels = await tasksResponse.Content.ReadFromJsonAsync<IEnumerable<TaskModel>>();

                return (tasksModels != null) ? tasksModels : new List<TaskModel>();

            }
            catch (Exception)
            {
                return new List<TaskModel>();
            }

        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            try
            {
                var tasksResponse = await _httpClient.PostAsJsonAsync("TaskList", task);
                var addedTask = await tasksResponse.Content.ReadFromJsonAsync<TaskModel>();

                return (addedTask != null) ? addedTask : null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            try
            {
                var tasksResponse = await _httpClient.PutAsJsonAsync("TaskList", task);
                var updatedTask = await tasksResponse.Content.ReadFromJsonAsync<TaskModel>();

                return (updatedTask != null) ? updatedTask : null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TaskModel> DeleteTask(int id)
        {
            try
            {
                var tasksResponse = await _httpClient.DeleteAsync("TaskList/" + id);
                var deletedTask = await tasksResponse.Content.ReadFromJsonAsync<TaskModel>();

                return (deletedTask != null) ? deletedTask : null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TaskModel> ChangeCompletionStatus(int id)
        {
            try
            {
                var getTasResponse = await _httpClient.GetAsync("TaskList/" + id);
                var taskToUpdate = await getTasResponse.Content.ReadFromJsonAsync<TaskModel>();

                taskToUpdate.IsCompleted = !taskToUpdate.IsCompleted;

                var tasksResponse = await _httpClient.PutAsJsonAsync("TaskList", taskToUpdate);
                var updatedTask = await tasksResponse.Content.ReadFromJsonAsync<TaskModel>();

                return (updatedTask != null) ? updatedTask : null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<TaskModel>> GetFilteredTasks(string filterText)
        {
            try
            {
                var tasksResponse = await _httpClient.GetAsync("TaskList/Filtered/"+filterText);
                var tasksModels = await tasksResponse.Content.ReadFromJsonAsync<IEnumerable<TaskModel>>();

                return (tasksModels != null) ? tasksModels : new List<TaskModel>();

            }
            catch (Exception)
            {
                return new List<TaskModel>();
            }
        }

        public async Task<IEnumerable<TaskModel>> GetSortedTasks(string sortText)
        {
            try
            {
                var tasksResponse = await _httpClient.GetAsync("TaskList/Sorted/" + sortText);
                var tasksModels = await tasksResponse.Content.ReadFromJsonAsync<IEnumerable<TaskModel>>();

                return (tasksModels != null) ? tasksModels : new List<TaskModel>();

            }
            catch (Exception)
            {
                return new List<TaskModel>();
            }
        }
    }

}


