using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Wearable.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Java.Interop;
using Android.Views.Animations;

namespace DevEnvWear
{
    [Activity(Label = "DevEnvWear", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
           
            var v = FindViewById<WatchViewStub>(Resource.Id.watch_view_stub);
            v.LayoutInflated += delegate
            {

                // Get our button from the layout resource,
                // and attach an event to it
                Button buttonmsdn = FindViewById<Button>(Resource.Id.msdnbutton);
                Button buttoncsharp = FindViewById<Button>(Resource.Id.csharpbutton);
                Button buttonblog = FindViewById<Button>(Resource.Id.bloggerbutton);

                buttonmsdn.Click += delegate
                {
                    var notification = new NotificationCompat.Builder(this)
                      .SetContentTitle("MSDN")
                        .SetContentText("https://social.msdn.microsoft.com/profile/j%20suthahar/")
                        .SetSmallIcon(Android.Resource.Drawable.StatNotifyVoicemail)
                        .SetGroup("group_key_demo").Build();

                    var manager = NotificationManagerCompat.From(this);
                    manager.Notify(1, notification);
                  
                    
                };
                buttoncsharp.Click += delegate
                {
                    var notification = new NotificationCompat.Builder(this)
                      .SetContentTitle("C# Corner")
                        .SetContentText("http://www.c-sharpcorner.com/members/suthahar-j")
                        .SetSmallIcon(Android.Resource.Drawable.StatNotifyVoicemail)
                        .SetGroup("group_key_demo").Build();

                    var manager = NotificationManagerCompat.From(this);
                    manager.Notify(1, notification);


                };
                buttonblog.Click += delegate
                {
                    var notification = new NotificationCompat.Builder(this)
                      .SetContentTitle("My Blog")
                        .SetContentText("www.devenvexe.com")
                        .SetSmallIcon(Android.Resource.Drawable.StatNotifyVoicemail)
                        .SetGroup("group_key_demo").Build();

                    var manager = NotificationManagerCompat.From(this);
                    manager.Notify(1, notification);


                };
            };
        }
    }
}


