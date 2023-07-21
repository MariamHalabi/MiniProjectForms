using System;
using System.Collections.Generic;
using System.Linq;
using MiniProjectForms.Models;
using MiniProjectForms.Services;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniProjectForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTaskPopUp : PopupPage
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
            };

            await _taskService.AddTask(newTask);

            await PopupNavigation.Instance.PopAsync();
        }
    }
}