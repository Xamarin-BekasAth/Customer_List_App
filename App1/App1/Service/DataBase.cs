using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App1
{
    public class DataBase
    {
        private readonly SQLiteAsyncConnection _connection;

        public DataBase(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Customer>();
        }

        public Task<List<Customer>> GetCustoemrsAsync()
        {
            return _connection.Table<Customer>().ToListAsync();
        }

        public Task<int> AddCustomerAsync(Customer cust)
        {
            return _connection.InsertAsync(cust);
        }

        public Task<int> UpdateCustomerAsync(Customer cust)
        {
            return _connection.UpdateAsync(cust);
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            return _connection.Table<Customer>().Where(cust => cust.Id == id ).FirstOrDefaultAsync();  
        }

        public Task<int> DeleteCustomerAsync(int id)
        {
             return _connection.DeleteAsync<Customer>(id);     
        }
    }
}
