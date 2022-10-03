using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Braintree;
using Eshop.Services;

namespace Eshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBraintreeService _braintreeService;

        public HomeController(ILogger<HomeController> logger, IBraintreeService braintreeService)
        {
            _logger = logger;
            _braintreeService = braintreeService;
        }

        public IActionResult Index()
        {
            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();  //Genarate a token
            ViewBag.ClientToken = clientToken;

            var data = new BookPurchaseVM
            {
                Id = 2,
                Description = "Hellow man",
                Author = "Me",
                Thumbnail = "This is thumbnail",
                Title = "This is title",
                Price = "0.1",
                Nonce = ""
            };

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Create(BookPurchaseVM model)
        {
            var gateway = _braintreeService.GetGateway();
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal("250"),
                PaymentMethodNonce = model.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                return View("Success");
            }
            else
            {
                return View("Failure");
            }
        }
    }




}
