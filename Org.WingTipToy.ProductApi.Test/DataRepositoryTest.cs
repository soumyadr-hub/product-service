using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Org.WingTipToy.ProductApi.BusinessLogic;
using Org.WingTipToy.ProductApi.BusinessLogic.Repositories;
using Org.WingTipToy.ProductApi.DataEntity;
using Org.WingTipToy.ProductApi.DataEntity.ConfigSections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Org.WingTipToy.ProductApi.Test
{
    public class DataRepositoryTest
    {
        public DataRepositoryTest()
        {
            MockedProductContext = Mock.Of<ProductContext>();
        }

        public ProductContext MockedProductContext { get; }

        [Fact]
        public async Task Success_GetCategoriesAsync_ReturnExpectedResult()
        {
            //Arrange
            var mockCategory = new Mock<DbSet<Category>>();
            Mock.Get(MockedProductContext)
                .Setup(c => c.Categories)
                .Returns(mockCategory.Object);

            //Act
            var dataRepository = new DataRepository(MockedProductContext);
            var actualResult = await dataRepository.GetCategoriesAsync().ConfigureAwait(false);

            //Assert
            actualResult.Should().BeEquivalentTo(new List<Category>
                {
                    new Category
                    {
                        CategoryId = 1,
                        CategoryName = "TestCategory",
                        Description = "TestDescription"
                    }
                });
        }

        private DbSet<T> GetQueryableMockDbSet<T>(IList<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            //dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }
    }
}
