using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoBayteq01.ViewModels;
using DemoBayteq01.Views;
using Xamarin.Forms;

namespace DemoBayteq01
{
    public partial class App : Application
    {
        private static PersonViewModel _personViewModel;
        public static PersonViewModel PersonViewModel
            => _personViewModel ?? (_personViewModel = new PersonViewModel());


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PersonListView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
