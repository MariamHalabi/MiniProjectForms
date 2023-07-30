using System;
using System.Collections.Generic;
using System.Linq;
using MiniProjectMaui.Models;
using MiniProjectMaui.Services;

namespace MiniProjectMaui.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTaskPopUp : ContentPage
    {
        private TaskService _taskService { get; set; }
        public NewTaskPopUp()
        {
            InitializeComponent();
            _taskService = new TaskService();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            string title = TaskTitleEntry.Text;
            string description = TaskDescriptionEntry.Text;
            DateTime dueDate = DueDatePicker.Date;

            TaskModel newTask = new TaskModel
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                IsCompleted = false,
                DeviceId = DeviceInfo.Name.ToString()
            };

            await _taskService.AddTask(newTask);

            await Navigation.PopModalAsync();
        }
    }
}