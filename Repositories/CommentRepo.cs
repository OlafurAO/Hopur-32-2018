using System.Linq;
using System.Collections.Generic;
using BookStore.Data;
using BookStore.Models.ViewModels;
using BookStore.Models;

namespace BookStore.Repositories
{
    public class CommentRepo
    {
        private DataContext _db;

        public CommentRepo()
        {
            _db = new DataContext();
        }
        
        public List<CommentListViewModel> GetCommentsForBook(int? ID)
        {
            var comments = (from c in _db.Comments
                            where ID == c.BookID
                            select new CommentListViewModel
                            {
                                BookID = c.ID,
                                Name = c.Name,
                                CommentBody = c.CommentBody
                            }
                            ).ToList();

            return comments;
        }

        public void AddCommentToBook(int ID, string Name, string CommentBody)
        {
            var comment = new Comment 
                          {
                              BookID = ID, 
                              Name = Name,
                              CommentBody = CommentBody
                          };
            _db.Add(comment);
            _db.SaveChanges();
        }
    }
}