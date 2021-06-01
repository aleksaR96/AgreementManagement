namespace AgreementManagement.Test.Data
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class AgreementRepositoryUnitTest
    {
        [Theory]
        [AutoMoqData]
        public void AgreementRepository_Insert_Successful(Agreement agreement)
        {
            Mock<DbSet<Agreement>> tableMock = new Mock<DbSet<Agreement>>();

            tableMock.Setup(x => x.Add(It.IsAny<Agreement>())).Verifiable();

            new AgreementRepository<Agreement>(tableMock.Object).Insert(agreement);

            tableMock.Verify(x => x.Add(It.IsAny<Agreement>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void AgreementRepository_Update_Successful(Agreement agreement)
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.Update(It.IsAny<Agreement>())).Verifiable();

            new AgreementRepository<Agreement>(contextMock.Object).Update(agreement);

            contextMock.Verify(x => x.Update(It.IsAny<Agreement>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void AgreementRepository_Delete_Successful(Agreement agreement)
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.Agreement.Find(It.IsAny<int>())).Verifiable();
            contextMock.Setup(x => x.Agreement.Remove(It.IsAny<Agreement>())).Verifiable();

            new AgreementRepository<Agreement>(contextMock.Object).Delete(agreement.Id);

            contextMock.Verify(x => x.Agreement.Find(It.IsAny<int>()), Times.Once);
            contextMock.Verify(x => x.Agreement.Remove(It.IsAny<Agreement>()), Times.Once);
        }

        [Fact]
        public void AgreementRepository_GetAll_Successful()
        {
            //Mock<DbSet<Agreement>> tableMock = new Mock<DbSet<Agreement>>();

            //tableMock.Setup(x => x.ToList()).Verifiable();

            //new AgreementRepository<Agreement>(tableMock.Object).GetAll();

            //tableMock.Verify(x => x.ToList(), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void AgreementRepository_GetById_Successful(Agreement agreement)
        {
            Mock<DbSet<Agreement>> tableMock = new Mock<DbSet<Agreement>>();

            tableMock.Setup(x => x.Find(agreement.Id)).Returns(agreement);

            Agreement result = new AgreementRepository<Agreement>(tableMock.Object).GetById(agreement.Id);

            Assert.Equal(result, agreement);

            tableMock.Verify(x => x.Find(agreement.Id), Times.Once);
        }

        [Fact]
        public void AgreementRepository_Save_Successful()
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.SaveChanges()).Verifiable();

            new AgreementRepository<Agreement>(contextMock.Object).Save();

            contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
