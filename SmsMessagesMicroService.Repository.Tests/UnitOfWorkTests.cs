using Microsoft.EntityFrameworkCore;
using Moq;
using SmsMessagesMicroService.Models.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SmsMessagesMicroService.Repository.Tests
{
    public class UnitOfWorkTests
    {
        private UnitOfWork _instance;
        //private readonly Repository<SmsMessages> _instance;
        public UnitOfWorkTests()
        {
            
        }

        [Fact]
        public void TestGetAll()
        {
            var context = new Mock<MessagesDbContext>();
            var testObject = new SmsMessages() { SmsMessagesId = 1 };
            var testList = new List<SmsMessages>() { testObject };

            var dbSetMock = new Mock<DbSet<SmsMessages>>();
            dbSetMock.As<IQueryable<SmsMessages>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<SmsMessages>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<SmsMessages>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<SmsMessages>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            context.Setup(x => x.Set<SmsMessages>()).Returns(dbSetMock.Object);

            // Act
            var _instance = new UnitOfWork(context.Object);

            var result = _instance.SmsMessages.GetAll();

            Assert.Equal(1, result.Result.Count());
        }
    }
}
