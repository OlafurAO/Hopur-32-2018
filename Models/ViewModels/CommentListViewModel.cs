namespace BookStore.Models.ViewModels{
  public class CommentListViewModel{
    public int ID { get; set; }
    public int BookID { get; set; }

    public string Name { get; set; }

    public string CommentBody { get; set; }
  }
}