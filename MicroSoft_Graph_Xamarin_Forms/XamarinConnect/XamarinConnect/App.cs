//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.

using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinConnect
{
    public class App : Application
    {
        public static string ClientID = "564aebe0-41f8-4a00-b083-aeaa4bf20a57";
        public static PublicClientApplication IdentityClientApp = new PublicClientApplication(ClientID);
        public static string[] Scopes = { "User.Read", "Mail.Send", "Files.ReadWrite" };
        public static string Username = string.Empty;
        public static string UserEmail = string.Empty;
        public App()
        {
            MainPage = new NavigationPage(new XamarinConnect.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
