using System.ComponentModel;
using Android.Widget;
using RadioButtons.Android.Renderer;
using RadioButtons.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomRadioButton), typeof(RadioButtonRenderer))]
namespace RadioButtons.Android.Renderer
{
    public class RadioButtonRenderer : ViewRenderer<CustomRadioButton, RadioButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged += ElementPropertyChanged;
            }

            if (Control == null)
            {
                var radioButton = new RadioButton(Context);
                radioButton.CheckedChange += RadioButtonCheckedChange;

                SetNativeControl(radioButton);
            }

            if (Control != null)
            {
                Control.Text = e.NewElement.Text;
                Control.Checked = e.NewElement.Checked;
            }

            Element.PropertyChanged += ElementPropertyChanged;
        }

        private void RadioButtonCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Element.Checked = e.IsChecked;
        }

        private void ElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;
                case "Text":
                    Control.Text = Element.Text;
                    break;
            }
        }
    }
}