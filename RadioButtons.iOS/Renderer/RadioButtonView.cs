using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace RadioButtons.iOS.Renderer
{
    [Register("RadioButtonView")]
    public class RadioButtonView : UIButton
    {
        public RadioButtonView()
        {
            Initialize();
        }

        public RadioButtonView(CGRect bounds)
            : base(bounds)
        {
            Initialize();
        }

        public bool Checked
        {
            set
            {
                Selected = value;
            }
            get
            {
                return Selected;
            }
        }

        public string Text
        {
            set
            {
                SetTitle(value, UIControlState.Normal);
            }
        }

        private void Initialize()
        {
            AdjustEdgeInsets();
            ApplyStyle();

            TouchUpInside += (sender, args) => Selected = !Selected;
        }

        private void AdjustEdgeInsets()
        {
            const float Inset = 8f;

            HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            ImageEdgeInsets = new UIEdgeInsets(0f, Inset, 0f, 0f);
            TitleEdgeInsets = new UIEdgeInsets(0f, Inset * 2, 0f, 0f);
        }

        private void ApplyStyle()
        {
            SetImage(UIImage.FromBundle("Images/checked.png"), UIControlState.Selected);
            SetImage(UIImage.FromBundle("Images/unchecked.png"), UIControlState.Normal);
        }
    }
}