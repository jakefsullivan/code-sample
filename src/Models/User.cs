namespace CodingExercise.Models
{
    public class Coordinates
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public Coordinates Coordinates { get; set; }
    }

    public class Hair
    {
        public string Color { get; set; }
        public string Type { get; set; }
    }

    public class Bank
    {
        public string CardExpire { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string Currency { get; set; }
        public string Iban { get; set; }
    }

    public class Company
    {
        public string Department { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }

        public Hair Hair { get; set; }
        public Address Address { get; set; }
        public Bank Bank { get; set; }
        public Company Company { get; set; }
    }
}
