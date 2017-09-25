using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBayteq01.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoBayteq01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPerson : ContentPage
    {
        public AddPerson()
        {
            InitializeComponent();
        }
        private bool FormValidation()
        {
            if (string.IsNullOrEmpty(EntryName.Text))
            {
                DisplayAlert("Error", "Ingrese el nombre", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(EntryEmail.Text)) //explicar validaciones en linea con Behaviors
            {
                DisplayAlert("Error", "Ingrese el correo electrónico", "OK");
                return false;
            }
            if (!string.IsNullOrEmpty(DatePickerBirthDay.Date.ToString())) return true;
            DisplayAlert("Error", "Seleccione la fecha de nacimiento", "OK");
            return false;
        }
        
        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (!FormValidation()) return;
            //App.PersonViewModel.AddPersonCommand.Execute(null);
            App.PersonViewModel.AddNewPerson(new Person()
            {
                Name = EntryName.Text,
                Email = EntryEmail.Text,
                Birthday = DatePickerBirthDay.Date,
                PublicPerson = SwitchPep.IsToggled
            });
            Navigation.PopAsync(false);
        }
    }
}
