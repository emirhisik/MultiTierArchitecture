namespace MultiTierArchitecture.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string Language { get; set; } = "TR";
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
