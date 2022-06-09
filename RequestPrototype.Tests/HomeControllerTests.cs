using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                new SymbolCompany {Symbol = "MSFT", Company = "Microsoft"},
                new SymbolCompany {Symbol="AAPL", Company = "Apple"}
            }).AsQueryable());
            HomeController controller = new HomeController(mock.Object);
            // Act
            HomeViewModel? model = (controller.Index() as ViewResult)?.ViewData.Model
            as HomeViewModel;

            IEnumerable<SymbolCompany>? result = model?.Companies;
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
