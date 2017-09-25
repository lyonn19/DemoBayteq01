using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoBayteq01.Models;
using Xamarin.Forms;

namespace DemoBayteq01.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        public PersonViewModel()
        {
            Personas = new ObservableCollection<Person>();
        }

        #region Funcionalidades

        public void AddNewPerson(Person nPerson)
        {
            Personas.Add(nPerson);
        }

        #endregion

        #region Propieddades

        private ObservableCollection<Person> _personas;

        public ObservableCollection<Person> Personas
        {
            get { return _personas; }
            set
            {
                _personas = value;
                OnPropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private DateTime _birthday;

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        private bool _publicPerson;

        public bool PublicPerson
        {
            get { return _publicPerson; }
            set
            {
                _publicPerson = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Modelos

        public async Task PersonModel()
        {
            // Supongo que esta es una tarea async
            await Task.Delay(10); // para evitar warning

            Personas.Add(new Person()
            {
                Name = "Yuri",
                Email = "y@gmail.com",
                Birthday = DateTime.Now,
                PublicPerson = false
            });

            Personas.Add(new Person()
            {
                Name = "Pepe",
                Email = "p@gmail.com",
                Birthday = DateTime.Now,
                PublicPerson = true
            });

            Personas.Add(new Person()
            {
                Name = "Juan",
                Email = "j@gmail.com",
                Birthday = DateTime.Now,
                PublicPerson = false
            });
        }

        #endregion

        #region Comandos

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        Command _getPersonCommand;

        public Command GetContactsCommand
        {
            get
            {
                return _getPersonCommand ?? (_getPersonCommand =
                           new Command(async () => await GetPersonAsync(), () => !IsBusy));
            }
        }

        public async Task GetPersonAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Personas.Clear();
                await PersonModel();
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        /*Command for Add*/
        public ICommand AddPersonCommand {

            get
            {
                return new Command(() => 
                {
                    Personas.Add(new Person()
                    {
                        Name = Name,
                        Email = Email,
                        Birthday = Birthday,
                        PublicPerson = PublicPerson
                    });
                });
            }
        }
        #endregion

        #region Notificación ViewModel

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion

    }
}
