using BookStore.Data.EntityModels;

namespace BookStore.Models.ViewModels
{
    public class CartListViewModel
    {
        public int _quantity;
        public class CartContents
        {
            public int ID { get; set; }

            public Book Book { get; set; }
        }
    }
}