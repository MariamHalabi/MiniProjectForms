using Xamarin.Forms;
using MiniProjectForms.Views;
using MiniProjectForms.Services;

namespace MiniProjectForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TaskListPage());
        }


        protected override void OnStart()
        {
            // Code exécuté au démarrage de l'application
        }

        protected override void OnSleep()
        {
            // Code exécuté lorsque l'application est mise en veille
        }

        protected override void OnResume()
        {
            // Code exécuté lorsque l'application est reprise depuis la veille
        }
    }
}
