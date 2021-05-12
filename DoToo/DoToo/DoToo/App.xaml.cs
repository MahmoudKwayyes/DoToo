using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoToo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

             MainPage = new NavigationPage(Resolver.Resolve<Views.MainView>());
            // MainPage = new Views.MainView(new ViewModels.MainViewModel(new Repositories.TodoItemRepository()));
            //MainPage = new Views.Page1();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
