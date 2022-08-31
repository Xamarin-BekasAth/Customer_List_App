using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SQLite;

namespace App1.ViewModel
{
    public class CustomerViewModel: INotifyPropertyChanged
    {
        private Customer _customer;
        public Customer Customer {
            get { return _customer; }
            set { _customer = value;
                OnPropertyChanged();
            } 
        }

        public ObservableCollection<Customer> Customers { get; set; }
        public Command LoadCustomersCmd { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public CustomerViewModel()
        {
            LoadCustomersCmd = new Command(async () => await ExcLoadCmd());
            Customers = new ObservableCollection<Customer>();
        }

        public async void OnAppearing()
        {
            await ExcLoadCmd();
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        async Task ExcLoadCmd()
        {
            Customers.Clear();
            var lcust = await App.Database.GetCustoemrsAsync();
            foreach (var customer in lcust)
            {
                Customers.Add(customer);
            }
        }
        

    }
}
