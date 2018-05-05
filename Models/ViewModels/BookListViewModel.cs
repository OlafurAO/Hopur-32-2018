namespace BookStore.Models.ViewModels
{
    public class BookListViewModel
    {
        public int ID { get; set;}

        public string Name { get; set;}

        public string Author { get; set;}

        public int AuthorID { get; set;}

        public string Category { get; set;}

        public string YearPublished { get; set;}

        public double Price { get; set;}

        public double Rating { get; set; }

        public int CopiesAvailable { get; set; }

        public int CopiesSold { get; set; }
    }

}