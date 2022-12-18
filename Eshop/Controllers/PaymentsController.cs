using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using Stripe.Checkout;
using Microsoft.Extensions.Options;
namespace Eshop.Controllers
{
	public class PaymentsController : Controller
	{
		public PaymentsController()
		{
			StripeConfiguration.ApiKey = "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";

		}


		[HttpPost]
		public ActionResult checkout(string data)
		{
			
			
			var options = new SessionCreateOptions
			{
				LineItems = new List<SessionLineItemOptions>
				{
				  new SessionLineItemOptions
				  {
				    PriceData = new SessionLineItemPriceDataOptions
				    {
				      UnitAmount = int.Parse(data),
				      Currency = "usd",
				      ProductData = new SessionLineItemPriceDataProductDataOptions
				      {
					Name = "Order",
				      },
				    },
				    Quantity = 1,
				  },
				},
				Mode = "payment",
				SuccessUrl = "http://localhost:4242/success",
				CancelUrl = "http://localhost:4242/cancel",
			};

			var service = new SessionService();
			Session session = service.Create(options);

			Response.Headers.Add("Location", session.Url);
			return new StatusCodeResult(303);

		}


	//		[HttpPost("create-checkout-session")]
	//	public ActionResult CreateCheckoutSession()
	//	{
	//		var options = new SessionCreateOptions
	//		{
	//			LineItems = new List<SessionLineItemOptions>
	//{
	//  new SessionLineItemOptions
	//  {
	//    PriceData = new SessionLineItemPriceDataOptions
	//    {
	//      UnitAmount = 2000,
	//      Currency = "usd",
	//      ProductData = new SessionLineItemPriceDataProductDataOptions
	//      {
	//	Name = "T-shirt",
	//      },
	//    },
	//    Quantity = 1,
	//  },
	//},
	//			Mode = "payment",
	//			SuccessUrl = "http://localhost:4242/success",
	//			CancelUrl = "http://localhost:4242/cancel",
	//		};

	//		var service = new SessionService();
	//		Session session = service.Create(options);

	//		Response.Headers.Add("Location", session.Url);
	//		return new StatusCodeResult(303);
	//	}
	}
}
