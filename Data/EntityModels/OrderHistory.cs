using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookStore.Models.ViewModels;

namespace BookStore.Models
{
    public partial class OrderHistory
    {
        [Key]
        public int ID { get; set; }

        public Order Order { get; set; }

    }
}