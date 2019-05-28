using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Data;
using System;

namespace QueMePongo.AccesoDatos.Tests.Helpers
{
    public class DbContextTestBase : IDisposable
    {
        protected readonly QueMePongoDbContext _dbContext;

        public DbContextTestBase()
        {
            var options = new DbContextOptionsBuilder<QueMePongoDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new QueMePongoDbContext(options);

            _dbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
