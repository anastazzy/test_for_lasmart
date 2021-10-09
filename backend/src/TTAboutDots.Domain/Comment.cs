namespace TTAboutDots.Domain
{
    public class Comment 
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }

        public int DotId { get; set; }
        public Dot Dot { get; set; }
    }
}
