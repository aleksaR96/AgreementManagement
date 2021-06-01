namespace AgreementManagement.Test.Data
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class ProductRepositoryUnitTest
    {
        [Theory]
        [AutoMoqData]
        public void ProductRepository_Insert_Successful(Product product)
        {
            Mock<DbSet<Product>> tableMock = new Mock<DbSet<Product>>();

            tableMock.Setup(x => x.Add(It.IsAny<Product>())).Verifiable();

            new ProductRepository<Product>(tableMock.Object).Insert(product);

            tableMock.Verify(x => x.Add(It.IsAny<Product>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void ProductRepository_Update_Successful(Product product)
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.Update(It.IsAny<Product>())).Verifiable();

            new ProductRepository<Product>(contextMock.Object).Update(product);

            contextMock.Verify(x => x.Update(It.IsAny<Product>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void ProductRepository_Delete_Successful(Product product)
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.Product.Find(It.IsAny<int>())).Verifiable();
            contextMock.Setup(x => x.Product.Remove(It.IsAny<Product>())).Verifiable();

            new ProductRepository<Product>(contextMock.Object).Delete(product.Id);

            contextMock.Verify(x => x.Product.Find(It.IsAny<int>()), Times.Once);
            contextMock.Verify(x => x.Product.Remove(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void ProductRepository_GetAll_Successful()
        {
            //Mock<DbSet<Product>> tableMock = new Mock<DbSet<Product>>();

            //tableMock.Setup(x => x.ToList()).Verifiable();

            //new ProductRepository<Product>(tableMock.Object).GetAll();

            //tableMock.Verify(x => x.ToList(), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void ProductRepository_GetById_Successful(Product product)
        {
            Mock<DbSet<Product>> tableMock = new Mock<DbSet<Product>>();

            tableMock.Setup(x => x.Find(product.Id)).Returns(product);

            Product result = new ProductRepository<Product>(tableMock.Object).GetById(product.Id);

            Assert.Equal(result, product);

            tableMock.Verify(x => x.Find(product.Id), Times.Once);
        }

        [Fact]
        public void ProductRepository_Save_Successful()
        {
            Mock<AgreementManagementContext> contextMock = new Mock<AgreementManagementContext>();

            contextMock.Setup(x => x.SaveChanges()).Verifiable();

            new ProductRepository<Product>(contextMock.Object).Save();

            contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
