using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBayteq01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoBayteq01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonListView : ContentPage
    {
        public PersonListView()
        {
            InitializeComponent();
            ListViewPersons.ItemsSource = App.PersonViewModel.Personas;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.PersonViewModel.Personas.Count == 0)
            {
                App.PersonViewModel.GetPersonsCommand.Execute(null);
            }
        }

        private void Contact_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPerson());
        }
    }
}
