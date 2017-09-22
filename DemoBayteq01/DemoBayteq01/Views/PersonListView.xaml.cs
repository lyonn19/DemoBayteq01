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
        PersonViewModel gg;
        public PersonListView()
        {
           
            InitializeComponent();
            BindingContext = gg = new PersonViewModel();
            ListViewContacts.ItemsSource = gg._personas;
        }

        protected override void OnAppearing()
        {
            
            gg.GetContactsCommand.Execute(null);
            base.OnAppearing();
        }
    }
}
