using System;

namespace Customer
{
    public class Distance
    {
        private static readonly double MeanEarthRadius = 6371.0088;

        public double ConvertDegToRadians(double degrees)
        {
            if (double.IsNaN(degrees)) throw new Exception("We can only convert numbers");

            return degrees * Math.PI / 180;
        }

        // Calculating distance of 2 points in a sphere: https://en.wikipedia.org/wiki/Great-circle_distance
        public double CalculateDistance(Destination office, Customer customer)
        {
            double distance;

            if (double.IsNaN(office.Latitude) || double.IsNaN(office.Longitude) || double.IsNaN(office.Latitude) ||
                double.IsNaN(office.Longitude))
                throw new Exception("Please enter valid coordinates");

            if (office.Latitude == 0 || office.Longitude == 0 || customer.Latitude == 0|| customer.Longitude == 0)
                throw new Exception("Please enter valid coordinates");

            try
            {
                var latRadian = ConvertDegToRadians(office.Latitude - customer.Latitude);
                var longRadian = ConvertDegToRadians(office.Longitude - customer.Longitude);
                var customerLatRadian = ConvertDegToRadians(customer.Latitude);
                var officeLatRadian = ConvertDegToRadians(office.Latitude);

                var dist = Math.Pow(Math.Sin(latRadian / 2), 2) +
                           Math.Cos(customerLatRadian) * Math.Cos(officeLatRadian) *
                           Math.Pow(Math.Sin(longRadian / 2), 2);

                var angle = Math.Atan2(Math.Sqrt(dist), Math.Sqrt(1 - dist)) * 2;

                distance = Math.Round(MeanEarthRadius * angle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return distance;
        }
    }
}