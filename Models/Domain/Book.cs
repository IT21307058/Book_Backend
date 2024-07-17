namespace BMS.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
            
        public required string Author { get; set; }
        public int ISBN { get; set; }

        public DateTime publicationDate { get; set; }
    }
}
