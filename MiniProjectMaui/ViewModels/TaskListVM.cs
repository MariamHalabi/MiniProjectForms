﻿using MiniProjectMaui.Models;
using MiniProjectMaui.Services;
using MiniProjectMaui.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniProjectMaui.ViewModels
{
    public class TaskListVM : INotifyPropertyChanged
    {
        private ITaskService taskService;

        private ObservableCollection<TaskModel> tasks;
        public IEnumerable<TaskModel> loadedTasks;

        public event EventHandler<TaskModel> TaskAddedEvent;


        public ObservableCollection<TaskModel> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        private string filterText;
        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                FilterTasks();
                OnPropertyChanged(nameof(FilterText));
            }
        }

        private TaskModel addedTask;
        public TaskModel AddedTask
        {
            get { return addedTask; }
            set
            {
                addedTask = value;
                OnPropertyChanged(nameof(AddedTask));
            }
        }

        private string sortProperty;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SortProperty
        {
            get { return sortProperty; }
            set
            {
                sortProperty = value;
                SortTasks();
                OnPropertyChanged(nameof(SortProperty));
            }
        }

        public ICommand FilterCommand { get; set; }
        public ICommand SortCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand OnTaskSelected { get; set; }

        public ICommand OpenTaskFormCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }

        public TaskListVM()
        {
            taskService = new TaskService();
            FilterCommand = new Command(FilterTasks);
            SortCommand = new Command(SortTasks);
            AddCommand = new Command(() => AddTask(AddedTask));
          //  OpenTaskFormCommand = new Command(OpenTaskForm);
            DeleteTaskCommand = new Command(DeleteTask);
            LoadTasks();
        }

        private async void LoadTasks()
        {
            loadedTasks = await taskService.GetTasks();
            Tasks = new ObservableCollection<TaskModel>(loadedTasks);
        }

        private void FilterTasks()
        {
        }

        private void SortTasks()
        {
        }


        private void AddTask(TaskModel task)
        {
            taskService.AddTask(task);
            OnPropertyChanged(nameof(Tasks));
        }

        //private async void OpenTaskForm()
        //{
        //    var popupNewTaskPage = new NewTaskPopUp();

        //    popupNewTaskPage.Disappearing += async (sender, e) =>
        //    {
        //        await Refresh();
        //    };

        //    await Navigation.Instance.PushAsync(popupNewTaskPage);


        //}


        private async void DeleteTask(object parameter)
        {
            await taskService.DeleteTask((int)parameter);
            await Refresh();
        }

        public async Task Refresh()
        {
            loadedTasks = await taskService.GetTasks();
            Tasks = new ObservableCollection<TaskModel>(loadedTasks);
            OnPropertyChanged(nameof(Tasks));

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
