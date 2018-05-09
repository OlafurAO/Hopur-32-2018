using System.ComponentModel.DataAnnotations;
using BookStore.Models.ViewModels;

namespace BookStore.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public int BookID { get; set; }
        public string Name { get; set; }
        public string CommentBody { get; set; }


    }
}