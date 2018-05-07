using BookStore.Data.EntityModels;

namespace BookStore.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int OrderId { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}