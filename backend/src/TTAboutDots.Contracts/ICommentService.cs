using System.Threading.Tasks;
using TTAboutDots.Domain;

namespace TTAboutDots.Contracts
{
    public interface ICommentService
    {
        Task<int> AddCommentAsync(CommentDto request);
    }
}
