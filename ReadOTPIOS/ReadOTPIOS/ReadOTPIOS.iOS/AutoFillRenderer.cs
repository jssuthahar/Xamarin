using ReadOTPIOS;
using ReadOTPIOS.iOS;
using UIKit;


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
