using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookStore.Models.ViewModels;

namespace BookStore.Models
{
    public partial class Order
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string BillingAddress { get; set; }
        public string ZipCode { get; set; }
        public double Total { get; set; }
        public System.DateTime OrderDate { get; set; }

        public List<CartListViewModel> Cart;

    }
}