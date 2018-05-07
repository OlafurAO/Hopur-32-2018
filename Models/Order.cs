using System.Collections.Generic;
 
namespace BookStore.Models
{
    public partial class Order
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public double Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}