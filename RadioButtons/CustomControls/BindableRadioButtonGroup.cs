using RadioButtons.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RadioButtons.CustomControls
{
    public class BindableRadioButtonGroup : StackLayout
    {
        public List<CustomRadioButton> RadioButtons;

        public BindableRadioButtonGroup()
        {
            RadioButtons = new List<CustomRadioButton>();
        }

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindableRadioButtonGroup, IEnumerable>(
                o => o.ItemsSource,
                default(IEnumerable),
                propertyChanged: OnItemsSourceChanged);

        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create<BindableRadioButtonGroup, int>(
                o => o.SelectedIndex,
                default(int),
                BindingMode.TwoWay,
                propertyChanged: OnSelectedIndexChanged);

        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndexProperty);
            }
            set
            {
                SetValue(SelectedIndexProperty, value);
            }
        }

        public event EventHandler<int> CheckedChanged;

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var radios = bindable as BindableRadioButtonGroup;

            if (radios == null)
            {
                return;
            }

            radios.RadioButtons.Clear();
            radios.Children.Clear();

            if (newvalue == null)
            {
                return;
            }

            var index = 0;
            foreach (var item in newvalue)
            {
                var radioButton = new CustomRadioButton { Text = item.ToString(), Id = index };

                radioButton.CheckedChanged += radios.OnCheckedChanged;

                radios.RadioButtons.Add(radioButton);

                radios.Children.Add(radioButton);
                index++;
            }
        }

        private void OnCheckedChanged(object sender, EventArgs<bool> e)
        {
            if (e.Value == false)
            {
                return;
            }

            var selectedRadio = sender as CustomRadioButton;

            foreach (var radio in RadioButtons)
            {
                if (selectedRadio != null && !selectedRadio.Id.Equals(radio.Id))
                {
                    radio.Checked = false;
                }
                else if (CheckedChanged != null)
                {
                    CheckedChanged.Invoke(sender, radio.Id);
                }
            }
        }

        private static void OnSelectedIndexChanged(BindableObject bindable, int oldvalue, int newvalue)
        {
            if (newvalue == -1)
            {
                return;
            }

            var bindableRadioGroup = bindable as BindableRadioButtonGroup;

            if (bindableRadioGroup == null)
            {
                return;
            }

            foreach (var radio in
                bindableRadioGroup.RadioButtons.Where(radio => radio.Id == bindableRadioGroup.SelectedIndex))
            {
                radio.Checked = true;
            }
        }
    }
}
