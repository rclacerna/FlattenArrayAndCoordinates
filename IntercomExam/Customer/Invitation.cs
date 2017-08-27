using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer
{
    public class Invitation
    {
        private IOrderedEnumerable<Customer> _orderedList;
        private readonly Destination _destination;
        private static double _maxDistance;
        private readonly string _file;

        public static void Main(string[] args)
        {
            var officeLocation = new Destination
            {
                Latitude = 53.339428,
                Longitude = -6.257664
            };

            var file = "customers.json";

            var invite = new Invitation(officeLocation, file);
            var invitedList = invite.SortInvitedCustomers(invite.InvitedCustomers());

            //sorted
            foreach (var customer in invitedList)
                Console.WriteLine(
                    $"Id: {customer.User_Id} | Name: {customer.Name}");
        }


        public Invitation(Destination destination, string file, double maxDistance = 100.00)
        {
            _destination = destination;
            _maxDistance = maxDistance;
            _file = file;
        }


        public List<Customer> InvitedCustomers()
        {
            var invitationList = new List<Customer>();
            var customers = new Customer();
            var distance = new Distance();

            try
            {
                foreach (var customer in customers.GetCustomerList(_file))
                {
                    var customerDistance = distance.CalculateDistance(_destination, customer);
                    if (customerDistance <= _maxDistance)
                        invitationList.Add(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return invitationList;
        }

        public IOrderedEnumerable<Customer> SortInvitedCustomers(List<Customer> invitedList)
        {
            if (!invitedList.Any())
                 throw  new Exception("You're invited list cannot be empty :)");

            try
            {
                _orderedList = invitedList.OrderBy(customer => customer.User_Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return _orderedList;
        }
    }
}
