using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.EntityModels
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public string CartID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public virtual Book Book { get; set; }        
    }
}