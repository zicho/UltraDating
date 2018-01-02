namespace UltraDatingHT17.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Recipient { get; set; }
    }
}