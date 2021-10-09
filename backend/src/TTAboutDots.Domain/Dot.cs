using System.Collections.Generic;

namespace TTAboutDots.Domain
{
    public class Dot
    {
        public int Id { get; set; }
        public double LocationX { get; set; }
        public  double LocationY { get; set; }
        public double Radius { get; set; }
        public string Color { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
