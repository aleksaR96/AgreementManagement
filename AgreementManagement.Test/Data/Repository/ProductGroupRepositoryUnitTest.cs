namespace AgreementManagement.Test.Data
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class ProductGroupRepositoryUnitTest
    {
        [Theory]
        [AutoMoqData]
        public void ProductGroupRepository_Insert_Successful(ProductGroup group)
        {
            Mock<DbSet<ProductGroup>> tableMock = new Mock<DbSet<ProductGroup>>();

            tableMock.Setup(x => x.Add(It.IsAny<ProductGroup>())).Verifiable();

            new ProductGroupRepository<ProductGroup>(tableMock.Object).Insert(group);

            tableMock.Verify(x => x.Add(It.IsAny<ProductGroup>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void ProductGroupRepository_Update_Successful(ProductGroup group)
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.Update(It.IsAny<ProductGroup>())).Verifiable();

            new ProductGroupRepository<ProductGroup>(contextMock.Object).Update(group);

            contextMock.Verify(x => x.Update(It.IsAny<ProductGroup>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void ProductGroupRepository_Delete_Successful(ProductGroup group)
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.ProductGroup.Find(It.IsAny<int>())).Verifiable();
            contextMock.Setup(x => x.ProductGroup.Remove(It.IsAny<ProductGroup>())).Verifiable();

            new ProductGroupRepository<ProductGroup>(contextMock.Object).Delete(group.Id);

            contextMock.Verify(x => x.ProductGroup.Find(It.IsAny<int>()), Times.Once);
            contextMock.Verify(x => x.ProductGroup.Remove(It.IsAny<ProductGroup>()), Times.Once);
        }

        [Fact]
        public void ProductGroupRepository_GetAll_Successful()
        {
            //Mock<DbSet<ProductGroup>> tableMock = new Mock<DbSet<ProductGroup>>();

            //tableMock.Setup(x => x.ToList()).Verifiable();

            //new ProductGroupRepository<ProductGroup>(tableMock.Object).GetAll();

            //tableMock.Verify(x => x.ToList(), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void ProductGroupRepository_GetById_Successful(ProductGroup group)
        {
            Mock<DbSet<ProductGroup>> tableMock = new Mock<DbSet<ProductGroup>>();

            tableMock.Setup(x => x.Find(group.Id)).Returns(group);

            ProductGroup result = new ProductGroupRepository<ProductGroup>(tableMock.Object).GetById(group.Id);

            Assert.Equal(result, group);

            tableMock.Verify(x => x.Find(group.Id), Times.Once);
        }

        [Fact]
        public void ProductGroupRepository_Save_Successful()
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.SaveChanges()).Verifiable();

            new ProductGroupRepository<ProductGroup>(contextMock.Object).Save();

            contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
