using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using RadioButtons.CustomControls;
using RadioButtons.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomRadioButton), typeof(RadioButtonRenderer))]
namespace RadioButtons.iOS.Renderer
{
    public class RadioButtonRenderer : ViewRenderer<CustomRadioButton, RadioButtonView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);

            BackgroundColor = Element.BackgroundColor.ToUIColor();

            if (Control == null)
            {
                var checkBox = new RadioButtonView(Bounds);
                checkBox.TouchUpInside += (s, args) => Element.Checked = Control.Checked;

                SetNativeControl(checkBox);
            }

            if (Control == null)
            {
                return;
            }

            Control.LineBreakMode = UILineBreakMode.CharacterWrap;
            Control.VerticalAlignment = UIControlContentVerticalAlignment.Top;
            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;
            Control.SetTitleColor(e.NewElement.TextColor.ToUIColor(), UIControlState.Normal);
            Control.SetTitleColor(e.NewElement.TextColor.ToUIColor(), UIControlState.Selected);
        }

        private void ResizeText()
        {
            var text = Element.Text;
            var bounds = Control.Bounds;
            var width = Control.TitleLabel.Bounds.Width;
            var height = text.StringSize(Control.Font, width, UILineBreakMode.Clip);
            var minimumHeight = string.Empty.StringSize(Control.Font, width, UILineBreakMode.Clip);
            var requiredLines = Math.Round(height.Height / minimumHeight.Height, MidpointRounding.AwayFromZero);
            var supportedLines = Math.Round(bounds.Height / minimumHeight.Height, MidpointRounding.ToEven);

            if (supportedLines != requiredLines)
            {
                bounds.Height += (float)(minimumHeight.Height * (requiredLines - supportedLines));
                Control.Bounds = bounds;
                Element.HeightRequest = bounds.Height;
            }
        }

        public override void Draw(CGRect rect)
        {
            ResizeText();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;
                case "Text":
                    Control.Text = Element.Text;
                    break;
                case "TextColor":
                    Control.SetTitleColor(Element.TextColor.ToUIColor(), UIControlState.Normal);
                    Control.SetTitleColor(Element.TextColor.ToUIColor(), UIControlState.Selected);
                    break;
                case "Element":
                    break;
                default:
                    return;
            }
        }
    }
}