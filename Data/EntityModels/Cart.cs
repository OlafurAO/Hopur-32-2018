namespace BookStore.Data.EntityModels
{
    public class Cart
    {
        public int _quantity;
        public class CartContents
        {
            public int ID { get; set; }

            public Book Book { get; set; }
        }

        public CartContents _cartContents;

        public Cart()
        {
            _cartContents = new CartContents();
        }
    }
}