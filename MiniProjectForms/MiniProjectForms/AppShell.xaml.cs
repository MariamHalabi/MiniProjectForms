using MiniProjectForms.ViewModels;
using MiniProjectForms.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MiniProjectForms
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnTaskDetailsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TaskDetailsPage");
        }
    }
}
