using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetails : ContentPage
    {
        Customer customer;
        public CustomerDetails(Customer customer)
        {
            InitializeComponent();

            this.customer = customer;   

            InitializePage();
        }

        public void InitializePage()
        {
            title.Text = "Customer #" + customer.Code;
            txtCode.Text = customer.Code;
            txtName.Text = customer.Name;
            txtAfm.Text = customer.Afm;
            txtTel.Text = customer.Tel; 
            txtAddress.Text = customer.Address; 
        }

        public async void OkClicked(object o, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}