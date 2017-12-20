namespace UltraDatingHT17.Models
{
    public class Shout
    {
        public int id { get; set; }
        public string Content { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Recipient { get; set; }
    }


}