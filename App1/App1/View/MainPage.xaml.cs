using App1.View;
using App1.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        CustomerViewModel customerView;

        public MainPage()
        {
            InitializeComponent();
            customerView = new CustomerViewModel();
            BindingContext = customerView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            customerView.OnAppearing();
        }

        private async void AddClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new AddCustomerPage()); 
        }

        private async void CustomerClicked(object sender, ItemTappedEventArgs args)
        {
            if (args.Item == null)
                return;

            await Navigation.PushAsync(new CustomerDetails(args.Item as Customer));
        }

        private async void EditClicked(object sender, EventArgs args)
        { 
            MenuItem b = (MenuItem)sender;
            Customer customer = b.CommandParameter as Customer;
            
            await Navigation.PushAsync(new EditCustomerPage(customer as Customer));
        }

    }
}
