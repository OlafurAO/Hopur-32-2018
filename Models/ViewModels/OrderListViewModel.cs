using System.ComponentModel.DataAnnotations;
using BookStore.Data.EntityModels;

namespace BookStore.Models.ViewModels{
    public class OrderListViewModel
    {
        [Key]
        public int ID { get; set; }
        public Order Order { get; set; }
    }
}