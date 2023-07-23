using MiniProjectMaui.Models;
using MiniProjectMaui.ViewModels;

namespace MiniProjectMaui.Views
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

        private async void OpenTaskForm(object sender, EventArgs e)
        {
            var popupNewTaskPage = new NewTaskPopUp();

            popupNewTaskPage.Disappearing += async (sender, e) =>
            {
                await viewModel.Refresh();
            };

            await Navigation.PushModalAsync(popupNewTaskPage);
        }
    }

}
