using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TTAboutDots.Contracts;
using Xunit;

namespace TTAboutDots.UnitTests
{
    public class CreateCommentTest : OptionsDataBase
    {
        private readonly App.CommentService _service;
        public CreateCommentTest()
        {
            _service = new App.CommentService(DbContext);
        }

        [Fact]
        public async Task CreateComment_ShouldAddCommentInDataBase()
        {
            // Arrange
            var request = new CommentDto
            {
                Color = "yellow",
                Text = "comment 1",
                Dot = 1
            };

            // Act
            var result = await _service.AddCommentAsync(request);

            // Assert
            await DbContext.Comments.SingleAsync(x => x.Id == result);
        }
    }
}
