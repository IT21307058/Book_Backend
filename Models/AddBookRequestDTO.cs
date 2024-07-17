namespace BMS.Models
{
    public class AddBookRequestDTO
    {
        public required string Title { get; set; }
        public string Description { get; set; }

        public required string Author { get; set; }
        public int ISBN { get; set; }

        public DateTime publicationDate { get; set; }
    }
}
