using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Auth;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DevEnvExeLogin.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        bool showLogin = true;
        private void LoginClick(object sendervalue, RoutedEventArgs e)
        {
            Button btnname = (Button)sendervalue;

            string providername = btnname.Content.ToString();


            if (showLogin && OAuthConfig.User == null)
            {
                showLogin = false;

                //Create OauthProviderSetting class with Oauth Implementation .Refer Step 6
                OAuthProviderSetting oauth = new OAuthProviderSetting();

                if (providername == "Twitter")
                {
                    var auth = oauth.LoginWithTwitter();
                    // After Twitter  login completed 
                    auth.Completed += (sender, eventArgs) =>
                    {
                        if (eventArgs.IsAuthenticated)
                        {
                            OAuthConfig.User = new UserDetails();
                            // Get and Save User Details 
                            OAuthConfig.User.Token = eventArgs.Account.Properties["oauth_token"];
                            OAuthConfig.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
                            OAuthConfig.User.TwitterId = eventArgs.Account.Properties["user_id"];
                            OAuthConfig.User.ScreenName = eventArgs.Account.Properties["screen_name"];

                            OAuthConfig.SuccessfulLoginAction.Invoke();
                        }
                        else
                        {
                            // The user cancelled
                        }
                    };


                    //Uri uri = auth.GetUI();
                    Type page_type = auth.GetUI();

                    //(System.Windows.Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri);
                    this.Frame.Navigate(page_type, auth);
                }
                else
                {
                    var auth = oauth.LoginWithProvider(providername);

                    // After facebook,google and all identity provider login completed 
                    auth.Completed += (sender, eventArgs) =>
                    {
                        if (eventArgs.IsAuthenticated)
                        {
                            OAuthConfig.User = new UserDetails();
                            // Get and Save User Details 
                            OAuthConfig.User.Token = eventArgs.Account.Properties["oauth_token"];
                            OAuthConfig.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
                            OAuthConfig.User.TwitterId = eventArgs.Account.Properties["user_id"];
                            OAuthConfig.User.ScreenName = eventArgs.Account.Properties["screen_name"];

                            OAuthConfig.SuccessfulLoginAction.Invoke();
                        }
                        else
                        {
                            // The user cancelled
                        }
                    };
                  
                    auth.Error += Auth_Error;
                    auth.BrowsingCompleted += Auth_BrowsingCompleted;

                    //Uri uri = auth.GetUI();
                    Type page_type = auth.GetUI();

                    //(System.Windows.Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri);
                    this.Frame.Navigate(page_type, auth);
                }
            }
        
    }
        private void Auth_Error(object sender, AuthenticatorErrorEventArgs ee)
        {
            string title = "OAuth Error";
            string msg = "";

            StringBuilder sb = new StringBuilder();
            sb.Append("Message  = ").Append(ee.Message)
                .Append(System.Environment.NewLine);
            msg = sb.ToString();

            //TODO: MessageBox.Show("Message = " + msg);

            return;

        }

        private void Auth_BrowsingCompleted(object sender, EventArgs ee)
        {
            string title = "OAuth Browsing Completed";
            string msg = "";

            StringBuilder sb = new StringBuilder();
            msg = sb.ToString();

            //TODO: MessageBox.Show("Message = " + msg);

            return;
        }

    }
}
