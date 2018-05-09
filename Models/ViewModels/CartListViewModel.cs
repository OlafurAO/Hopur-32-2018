using BookStore.Data.EntityModels;

namespace BookStore.Models.ViewModels
{
    public class CartListViewModel
    {        
        public int ID { get; set; }
        public string CartID { get; set; }
        public Book Book { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
    }
}