namespace Libruary.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; } = null!; // Допускает значения NULL
        public string LastName { get; set; } = null!;  // Допускает значения NULL
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
