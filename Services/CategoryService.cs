using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;
using BookStore.Repositories;

namespace BookStore.Services
{
  public class CategoryService
  {
        private CategoryRepo _categories; 
        public CategoryService(){
            _categories = new CategoryRepo();

        }
    public List<BookListViewModel> Filter(string i)
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