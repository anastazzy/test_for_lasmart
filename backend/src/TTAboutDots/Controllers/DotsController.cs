using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTAboutDots.Contracts;

namespace TTAboutDots.Host.Controllers
{

    [Route("api/dots")]
    [ApiController]
    public class DotsController
    {
        private readonly IDotService _service;

        public DotsController(IDotService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<DotDto[]> GetDots()
        {
            return _service.GetDotsAsync();
        }

        [HttpDelete]
        public Task<bool> DeleteDot(int id)
        {
            return _service.DeleteDotAsync(id);
        }

    }
}
