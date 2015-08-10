using RadioButtons.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RadioButtons
{
    public partial class Home : ContentPage
    {
        private readonly HomeViewModel _viewModel;

        public Home()
        {
            _viewModel = new HomeViewModel();

            BindingContext = _viewModel;

            InitializeComponent();

            RegisterCustomControlActions();
        }

        private void RegisterCustomControlActions()
        {
            //These are apparently necessary, as the 2 way binding is not sticking.
            RadioGroupTestCount.CheckedChanged += (o, e) =>
            {
                var radio = o as CustomRadioButton;

                if (radio == null || radio.Id == -1)
                {
                    return;
                }

                _viewModel.NumberOfTests = radio.Id;
            };
        }
    }
}
