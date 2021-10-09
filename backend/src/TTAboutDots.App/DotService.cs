using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TTAboutDots.Contracts;
using TTAboutDots.DataAccess;
using TTAboutDots.Domain;

namespace TTAboutDots.App
{
    public class DotService : IDotService
    {
        private readonly TTADDbContext _dbContext;

        public DotService(TTADDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddDotAsync(DotDto request)
        {
            var point = new Dot
            {
                Color = request.Color,
                LocationX = request.LocationX,
                LocationY = request.LocationY,
                Comments = request.Comments?.Select(x => new Domain.Comment
                {
                    Text = x.Text,
                }),
            };
            await _dbContext.Dots.AddAsync(point);
            await _dbContext.SaveChangesAsync();
            return point.Id;
        }
        public async Task<bool> DeleteDotAsync(int id)
        {
            var result = await _dbContext.Dots.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) return false;
            _dbContext.Dots.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<DotDto[]> GetDotsAsync()
        {
            return _dbContext.Dots.Include(x => x.Comments).Select(
                dot => new DotDto
                {
                    LocationX = dot.LocationX,
                    LocationY = dot.LocationY,
                    Color = dot.Color,
                    Comments = dot.Comments.Select(y => new CommentDto()
                    {
                        Color = y.Color,
                        Text = y.Text,
                    }),
                    Radius = dot.Radius,

                }).ToArrayAsync();
        }

        
    }
}
