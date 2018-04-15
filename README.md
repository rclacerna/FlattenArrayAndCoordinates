# Flatten Nested Arrays and Invite Customers to coordinates
This solution is implemented in .NET Core and C#

# Flatten Nested Arrays
FlattenArray.cs flattens the nested arrays.
FlattenArrayTests.cs are the unit-tests for testing both positive and negative assertions

# Invite Customers
Invitation.cs is the parent class that invites customers within a given limit and sort the list of customers by id:
- Distance.cs: this calculates the distance between two points
- Customer.cs: this reads from a file and maps the data

# How to load the program for inviting customers
```sh
            var officeLocation = new Destination { Latitude = 53.339428, Longitude = -6.257664 };

            var invite = new Invitation(officeLocation, "customers.json");
            var invitedList = invite.SortInvitedCustomers(invite.InvitedCustomers());

            foreach (var customer in invitedList) Console.WriteLine( $"Id: {customer.User_Id} | Name: {customer.Name}");
```
# How to load the program for flattening arrays
```sh
            var nestedList = new List<object>
                {1, new List<object> {2}, new List<object> {new List<object> {3, 4}, 5}};

            var values = string.Join(", ", Flatten(nestedList));
            Console.WriteLine("[{0}]", values);
```
