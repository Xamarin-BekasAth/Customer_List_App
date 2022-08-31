using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModel
{
    class AddCustomerViewModel
    {
        public Customer newCustomer { get; set; }

        public ICommand AddCmd => new Command(AddCustomer);

        public AddCustomerViewModel()
        {
            newCustomer = new Customer();   
        }

        public async void AddCustomer()
        {
            bool validData = true;

            if(string.IsNullOrWhiteSpace(newCustomer.Code)) validData = false;
            if(string.IsNullOrWhiteSpace(newCustomer.Name)) validData = false;
            if(string.IsNullOrWhiteSpace(newCustomer.Tel)) validData = false;
            if(string.IsNullOrWhiteSpace(newCustomer.Afm)) validData = false;
            if(string.IsNullOrWhiteSpace(newCustomer.Tel)) validData = false;

            if(validData)
            {
                await App.Database.AddCustomerAsync(newCustomer);
                //MessagingCenter.Send(this, "AddCustomer", newCustomer);
                await App.Current.MainPage.Navigation.PopAsync();
            }else
            {
                UserDialogs.Instance.Alert("Invalid Data", "Retry");
            }
        }


    }
}
