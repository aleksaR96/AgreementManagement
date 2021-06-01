namespace AgreementManagement.Test.Data
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class AspNetUsersRepositoryUnitTest
    {
        [Theory]
        [AutoMoqData]
        public void AspNetUsersRepository_Insert_Successful(AspNetUsers user)
        {
            Mock<DbSet<AspNetUsers>> tableMock = new Mock<DbSet<AspNetUsers>>();

            tableMock.Setup(x => x.Add(It.IsAny<AspNetUsers>())).Verifiable();

            new AspNetUsersRepository<AspNetUsers>(tableMock.Object).Insert(user);

            tableMock.Verify(x => x.Add(It.IsAny<AspNetUsers>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void AspNetUsersRepository_Update_Successful(AspNetUsers user)
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.Update(It.IsAny<AspNetUsers>())).Verifiable();

            new AspNetUsersRepository<AspNetUsers>(contextMock.Object).Update(user);

            contextMock.Verify(x => x.Update(It.IsAny<AspNetUsers>()), Times.Once);
        }

        [Fact]
        public void AspNetUsersRepository_GetAll_Successful()
        {
            //Mock<DbSet<AspNetUsers>> tableMock = new Mock<DbSet<AspNetUsers>>();

            //tableMock.Setup(x => x.ToList()).Verifiable();

            //new AspNetUsersRepository<AspNetUsers>(tableMock.Object).GetAll();

            //tableMock.Verify(x => x.ToList(), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void AspNetUsersRepository_GetById_Successful(AspNetUsers user)
        {
            Mock<DbSet<AspNetUsers>> tableMock = new Mock<DbSet<AspNetUsers>>();

            tableMock.Setup(x => x.Find(user.Id)).Returns(user);

            AspNetUsers result = new AspNetUsersRepository<AspNetUsers>(tableMock.Object).GetById(user.Id);

            Assert.Equal(result, user);

            tableMock.Verify(x => x.Find(user.Id), Times.Once);
        }

        [Fact]
        public void AspNetUsersRepository_Save_Successful()
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.SaveChanges()).Verifiable();

            new AspNetUsersRepository<AspNetUsers>(contextMock.Object).Save();

            contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
