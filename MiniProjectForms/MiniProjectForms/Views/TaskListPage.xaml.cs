using Xamarin.Forms;
using MiniProjectForms.Views;
using MiniProjectForms.ViewModels;
using MiniProjectForms.Models;
using MiniProjectForms.Services;
using System;

namespace MiniProjectForms.Views
{
    public partial class TaskListPage : ContentPage
    {
        private TaskListVM viewModel;

        public TaskListPage()
        {
            InitializeComponent();
            viewModel = new TaskListVM();
            BindingContext = viewModel;
        }

        private async void OnTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is TaskModel selectedTask)
            {
                var taskDetailsPage = new TaskDetailsPage((TaskModel)e.SelectedItem);

                taskDetailsPage.Disappearing += async (senderr, ee) =>
                {
                    await viewModel.Refresh();
                };

                await Navigation.PushAsync(page: taskDetailsPage);
            }


        }

        private void DeleteTask(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int taskId = (int)button.CommandParameter;
            viewModel.DeleteTaskCommand.Execute(taskId);
        }
    }

}
