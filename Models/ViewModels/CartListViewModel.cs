using BookStore.Data.EntityModels;

namespace BookStore.Models.ViewModels
{
    public class CartListViewModel
    {
        public int Quantity;
        
        public int ID { get; set; }

        public Book Book { get; set; }
        
    }
}