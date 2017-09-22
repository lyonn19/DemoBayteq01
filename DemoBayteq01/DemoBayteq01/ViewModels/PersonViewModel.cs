using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DemoBayteq01.Models;
using Xamarin.Forms;

namespace DemoBayteq01.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public IList<Person> _personas { get; set; }

        public PersonViewModel()
        {
            _personas = new ObservableCollection<Person>();
        }

        #region Notificación ViewModel

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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

        private string _publicPerson;

        public string PublicPerson
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

        public async Task ContactModel()
        {
            _personas.Add(new Person()
                {
                    Name = "Yuri",
                    Email = "y@gmail.com",
                    Birthday = DateTime.Now,
                    PublicPerson = false
                }
            );

            _personas.Add(new Person()
                {
                    Name = "Pepe",
                    Email = "p@gmail.com",
                    Birthday = DateTime.Now,
                    PublicPerson = true
                }
            );

            _personas.Add(new Person()
                {
                    Name = "Juan",
                    Email = "j@gmail.com",
                    Birthday = DateTime.Now,
                    PublicPerson = false
                }
            );
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

        Command _getContactsCommand;
        public Command GetContactsCommand
        {
            get
            {
                return _getContactsCommand ?? (_getContactsCommand = new Command(async () => await GetContactsAsync(), () => !IsBusy));
            }
        }
        public async Task GetContactsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                _personas.Clear();
                await ContactModel();
            }
            finally
            {
                IsBusy = false;
            }
        }


        #endregion

    }
}
