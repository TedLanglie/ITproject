using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RequestPrototype.Controllers;
using RequestPrototype.Models;
using Xunit;
namespace RequestPrototype.Tests
{
    public class HomeControllerTests
    {
        [Fact]
      
        public void Can_Use_Repository()
        {
            // Arrange
            Mock<ISymbolCompanyRepository> mock = new Mock<ISymbolCompanyRepository>();
            mock.Setup(m => m.Companies).Returns((new SymbolCompany[] {
                new SymbolCompany {Id=1, Company = "Microsoft", Symbol="MSFT"},
                new SymbolCompany {Id = 2, Company = "Apple", Symbol="AAPL"}
            }).AsQueryable());
            HomeController controller = new HomeController(mock.Object);
            // Act
            IEnumerable<SymbolCompany>? result = (controller.Index() as ViewResult)?.ViewData.Model
            as IEnumerable<SymbolCompany>;
            // Assert
            SymbolCompany[] prodArray = result?.ToArray() ?? Array.Empty<SymbolCompany>();

            Assert.True(prodArray.Length == 2);
            Assert.Equal("Microsoft", prodArray[0].Company);
            Assert.Equal("MSFT", prodArray[0].Symbol);
            Assert.Equal("Apple", prodArray[1].Company);
            Assert.Equal("AAPL", prodArray[1].Symbol);
        }
    }
}
