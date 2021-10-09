using System.Threading.Tasks;
using TTAboutDots.Domain;

namespace TTAboutDots.Contracts
{
    public interface IDotService
    {
        Task<int> AddDotAsync(DotDto request);
        Task<bool> DeleteDotAsync(int id);
        Task<DotDto[]> GetDotsAsync();
    }
}
