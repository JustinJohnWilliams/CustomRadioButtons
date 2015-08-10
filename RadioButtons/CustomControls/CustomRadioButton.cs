using RadioButtons.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RadioButtons.Extensions;

namespace RadioButtons.CustomControls
{
    public class CustomRadioButton : View
    {
        public new int Id { get; set; }

        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create<CustomRadioButton, bool>(p => p.Checked, false);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<CustomRadioButton, string>(p => p.Text, String.Empty);

        public EventHandler<EventArgs<bool>> CheckedChanged;

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create<CustomRadioButton, Color>(p => p.TextColor, Color.Black);

        public bool Checked
        {
            get
            {
                return this.GetValue<bool>(CheckedProperty);
            }
            set
            {
                SetValue(CheckedProperty, value);
                var eventHandler = CheckedChanged;
                if (eventHandler != null)
                {
                    eventHandler.Invoke(this, value);
                }
            }
        }

        public string Text
        {
            get
            {
                return this.GetValue<string>(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return this.GetValue<Color>(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }
    }
}
