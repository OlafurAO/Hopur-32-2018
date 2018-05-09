using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;
using BookStore.Repositories;

namespace BookStore.Services
{
  public class Search
  {
        private CategoryRepo _categories; 
        public Search(){
            _categories = new CategoryRepo();

        }
    public List<BookListViewModel> Filter(int? i)
        {
            var result = _categories.FindBooksByCategory(i);
             return result;
             }
    public  List<CategoryListViewModel> GetCategories(){
        var categories = _categories.GetAllCategories();
        return categories; 
    }
    }

}