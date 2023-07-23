using MiniProjectMaui.Models;
using MiniProjectMaui.Services;
using MiniProjectMaui.ViewModels;
using System;

namespace MiniProjectMaui.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDetailsPage : ContentPage
    {
        private TaskModel CurrentTask;
        private ITaskService _taskService;
        private TaskListVM taskListVm;
        public TaskDetailsPage(TaskModel currentTask)
        {
            CurrentTask = currentTask;
            InitializeComponent();
            _taskService = new TaskService();
            this.BindingContext = new TaskDetailsVM(CurrentTask);
        }

        private async void Coucou(object sender, EventArgs e)
        {
            string newTitle = Title.Text;
            string newDescription = Description.Text;
            DateTime newDueDate = DueDate.Date;

            var newTask = this.CurrentTask;

            newTask.Title = newTitle;
            newTask.Description = newDescription;
            newTask.DueDate = newDueDate;

            CurrentTask = await _taskService.UpdateTask(newTask);
            OnPropertyChanged(nameof(CurrentTask));
        }
    }
}