using Microsoft.EntityFrameworkCore;
using System;

namespace SmsMessagesMicroService.Repository.Tests.Database
{
    public class TestDatabase : IDisposable
    {
        protected readonly MessagesDbContext Context;

        public TestDatabase()
        {
            var options = new DbContextOptionsBuilder<MessagesDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            Context = new MessagesDbContext(options);

            Context.Database.EnsureCreated();

            DatabaseInit.Initialize(Context);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();

            Context.Dispose();
        }
    }
}
