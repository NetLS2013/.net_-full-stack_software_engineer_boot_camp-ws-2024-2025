namespace rent_for_students.Models
{
    public enum RoomType
    {
        Any = 0,
        Studio,
        Room,
        Apartment
    }

    public class HousingListing
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string City { get; set; } = "";
        public string Address { get; set; } = "";
        public decimal Price { get; set; }
        public RoomType RoomType { get; set; }
        public string Description { get; set; } = "";
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
