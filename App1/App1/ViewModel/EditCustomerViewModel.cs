using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class EditCustomerViewModel
    {

        public ICommand EditCmd => new Command(EditCustomer);
        public Customer customer { get; set; }       

        public EditCustomerViewModel()
        {
            customer = new Customer();
        }

        public async void EditCustomer()
        {

            bool validData = true;

            if (string.IsNullOrWhiteSpace(customer.Code)) validData = false;
            if (string.IsNullOrWhiteSpace(customer.Name)) validData = false;
            if (string.IsNullOrWhiteSpace(customer.Tel)) validData = false;
            if (string.IsNullOrWhiteSpace(customer.Afm)) validData = false;
            if (string.IsNullOrWhiteSpace(customer.Tel)) validData = false;

            if (validData)
            {
                int rows = await App.Database.UpdateCustomerAsync(customer);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                UserDialogs.Instance.Alert("Invalid Data", "Retry");
            }

        }
    }
}
