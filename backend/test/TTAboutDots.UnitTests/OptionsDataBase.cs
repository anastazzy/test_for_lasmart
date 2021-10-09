using System;
using Microsoft.EntityFrameworkCore;
using TTAboutDots.DataAccess;

namespace TTAboutDots.UnitTests
{
    public class OptionsDataBase
    {
        protected TTADDbContext DbContext { get; }
        protected OptionsDataBase()
        {
            var options = new DbContextOptionsBuilder<TTADDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            DbContext = new TTADDbContext(options);
        }
    }
}
