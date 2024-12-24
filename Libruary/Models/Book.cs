namespace Libruary.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } = null!; // Допускает значения NULL
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public int CategoryID { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; } = null!;  // Допускает значения NULL
        public int Quantity { get; set; }
    }
}
