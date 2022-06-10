namespace Models
{
    public interface IBookModel
    {
        string Author { get; set; }
        decimal Cost { get; set; }
        string Description { get; set; }
        int ID { get; set; }
        string? ImageUrl { get; set; }
        string ISBN { get; set; }
        DateTime LastModified { get; set; }
        int LibraryID { get; set; }
        string Title { get; set; }
        int Year { get; set; }

        string ToString();
    }
}