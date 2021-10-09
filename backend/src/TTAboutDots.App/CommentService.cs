using System.Threading.Tasks;
using TTAboutDots.Contracts;
using TTAboutDots.DataAccess;
using TTAboutDots.Domain;

namespace TTAboutDots.App
{
    public class CommentService : ICommentService
    {
        private readonly TTADDbContext _dbContext;

        public CommentService(TTADDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCommentAsync(CommentDto request)
        {
            var comment = new Comment
            {
                Color = request.Color,
                Text = request.Text,
                DotId = request.Dot
            };
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return comment.Id;
        }
    }
}
