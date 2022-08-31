using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id {get; set;}
        public string Code    {get; set;}
        public string Afm { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }


        public Customer() { }
        public Customer(int anId, string aCode, string afm, string name, string tel, string address)
        {
            Id = anId;
            Code = aCode;
            Afm = afm;
            Name = name;
            Tel = tel;
            Address = address;
        }

        public Customer Clone()
        {
            Customer newCustomer = new Customer();

            newCustomer.Id = Id;
            newCustomer.Code = Code;
            newCustomer.Afm = Afm;
            newCustomer.Tel = Tel;
            newCustomer.Name = Name;    

            return newCustomer;
        }
    }
}