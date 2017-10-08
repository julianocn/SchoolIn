using System;

using UIKit;

namespace SchoolIn.iOSx
{
    public partial class ViewController : UIViewController
    {
        partial void UIButton195_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "SchoolIn",
                Message = txtUsuario.Text + " acessando o app"
            };
            alert.AddButton("OK");
            alert.Show();
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
