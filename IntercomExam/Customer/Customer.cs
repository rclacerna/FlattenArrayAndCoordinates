using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Customer
{
    public class Customer
    {
        public string Name { get; set; }

        public int User_Id { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public List<Customer> GetCustomerList(string fileName)
        {
            var customersList = new List<Customer>();

            try
            {
                var file = File.ReadAllLines(fileName);

                foreach (var item in file)
                {
                    var getCustomer = JsonConvert.DeserializeObject<Customer>(item);

                    customersList.Add(new Customer
                    {
                        Name = getCustomer.Name,
                        User_Id = getCustomer.User_Id,
                        Latitude = getCustomer.Latitude,
                        Longitude = getCustomer.Longitude
                    });
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return customersList;
        }
    }
}
