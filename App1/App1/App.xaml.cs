using Acr.UserDialogs;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        private static DataBase db;
        public static DataBase Database
        {
            get { 
                if(db == null)
                {
                    db = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.
                        SpecialFolder.LocalApplicationData), "customers.db3"));
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
