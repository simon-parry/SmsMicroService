using Moq;
using SmsMessagesMicroService.Models.Models;
using Xunit;

namespace SmsMessagesMicroService.Repository.Tests
{
    public class RepositoryTests 
    {
        private readonly Mock<MessagesDbContext> _MessagesContext;
        private readonly Repository<SmsMessages> _instance;



        public RepositoryTests()
        {


            

        

        }

        [Fact]
        public void TestGetAll()
        {
            //var context = new Mock<DbContextOptions<MessagesDbContext>>();
            //var testObject = new SmsMessages() { SmsMessagesId = 1 };
            //var testList = new List<SmsMessages>() { testObject };

            //var dbSetMock = new Mock<DbSet<SmsMessages>>();
            //dbSetMock.As<IQueryable<SmsMessages>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            //dbSetMock.As<IQueryable<SmsMessages>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            //dbSetMock.As<IQueryable<SmsMessages>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            //dbSetMock.As<IQueryable<SmsMessages>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            //context.Setup(x => x.Set<SmsMessages>()).Returns(dbSetMock.Object);

            //var ss = new MessagesDbContext(context.Object);

           

            //// Act
            //var instance = new Repository<SmsMessages>(ss);

            //var result = instance.GetAll();

            //Assert.Equal(1, result.Result.Count());
        }
    }
}
