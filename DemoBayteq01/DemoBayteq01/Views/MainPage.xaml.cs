using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBayteq01.Views;
using DemoBayteq01.Views.Page2;
using DemoBayteq01.Views.Page3;
using Xamarin.Forms;

namespace DemoBayteq01
{
    public partial class MainPage : TabbedPage
    {
        private readonly NavigationPage _tabPage1;
        private readonly NavigationPage _tabPage2;
        private readonly NavigationPage _tabPage3;

        public MainPage()
        {
            InitializeComponent();

            _tabPage1 = new NavigationPage(new PersonListView())
            {
                Title = "Page1"
            };
            Children.Add(_tabPage1);

            _tabPage2 = new NavigationPage(new Page2())
            {
                Title = "Page2"
            };
            Children.Add(_tabPage2);

            _tabPage3 = new NavigationPage(new Page3())
            {
                Title = "Page3"
            };
            Children.Add(_tabPage3);

        }

    }
}
