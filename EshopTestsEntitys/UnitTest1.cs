using Eshop.Controllers;
using Eshop.Data;
using Eshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xunit;
namespace EshopTestsEntitys
{
    public class HomeControllerTest
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly EshopContext _context;
        [Fact]
        public void Test_Index_ReturnsViewName()
        {


            var controller = new HomeController(_logger);
            var result = controller.Index() as ViewResult;

            Assert.Equal("Index", result?.ViewName);

        }


        [Fact]
        public void CheckIfOutputIsExpected()
        {
            var num = new ProductsController(userManager,signInManager,_context);

            int result = num.Add(20, 10); //will add both numbers

            Assert.Equal<int>(30, result); //check if result is equal to expected value 30
        }



        //[Fact]
        //public void Test_Index_ReturnsViewData()
        //{
        //    var controller = new HomeController(_logger);
        //    var result = controller.Index() as ViewResult;
        //    var product = (Product?)result?.ViewData.Model;
        //    Assert.Null(product);
        //}
    }
}