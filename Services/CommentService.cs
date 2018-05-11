using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;
using BookStore.Repositories;

namespace BookStore.Services
{
  public class CommentService
  {
        private CommentRepo _comments; 

        public CommentService()
        {
            _comments = new CommentRepo();
        }
        
        public  List<CommentListViewModel> GetComments(int? ID)
        {
            var comments = _comments.GetCommentsForBook(ID);
            return comments; 
        }

        public void AddComment(int ID, string Name, string CommentBody)
        {
            _comments.AddCommentToBook(ID, Name, CommentBody);
        }
    }
}