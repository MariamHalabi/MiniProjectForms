using MiniProjectMaui.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProjectMaui.ViewModels
{
    public class TaskDetailsVM
    {
        public TaskModel CurrentTask { get; set; }
        public TaskDetailsVM(TaskModel currentTask) { 
            this.CurrentTask = currentTask;
        
        }
        public TaskDetailsVM()
        {

        }

    }
}
