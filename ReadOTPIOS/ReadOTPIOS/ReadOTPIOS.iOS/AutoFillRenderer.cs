using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ReadOTPIOS;
using ReadOTPIOS.iOS;
[assembly: ExportRenderer(typeof(AutoFillControl), typeof(AutoFillRenderer))]
namespace ReadOTPIOS.iOS
{
   
    public class AutoFillRenderer: EntryRenderer
    {
       
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.TextContentType = UITextContentType.OneTimeCode;
            }
        }
    }
}
