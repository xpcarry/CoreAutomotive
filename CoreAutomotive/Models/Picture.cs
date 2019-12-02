namespace CoreAutomotive.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string PictureUrl { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }

    }
}