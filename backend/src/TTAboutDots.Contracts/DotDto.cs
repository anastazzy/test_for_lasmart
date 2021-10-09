using System.Collections.Generic;

namespace TTAboutDots.Contracts
{
    public class DotDto
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double Radius { get; set; }
        public string Color { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
    }
}
