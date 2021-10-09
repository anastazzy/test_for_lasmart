using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TTAboutDots.Contracts;
using Xunit;

namespace TTAboutDots.UnitTests
{
    public class CreateDotTest : OptionsDataBase
    {
        private readonly App.DotService _service;
        public CreateDotTest()
        {
            _service = new App.DotService(DbContext);
        }

        [Fact]
        public async Task CreateDot_ShouldAddDotInDatabase()
        {
            // Arrange
            var request = new DotDto
            {
                Color = "red",
                LocationX = 12,
                LocationY = 15,
                Radius = 5
            };

            // Act
            var result = await _service.AddDotAsync(request);
            

            //Assert
            await DbContext.Dots.SingleAsync(x => x.Id == result);
        }
    }
}
