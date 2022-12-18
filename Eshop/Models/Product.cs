using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Eshop.Models
{
	public class Product
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public int Price { get; set; }

		public List<BasketProduct> Baskets { get; set; } = new();

		public string ImageTitle { get; set; } = string.Empty;

		[NotMapped]
		[DisplayName("Upload File")]
		public IFormFile ImageFile { get; set; }

		public ProductType Type { get; set; }
	}
	public enum ProductType
	{
		HomeAppliances,
		Instruments,
		SmartphonesAndGadgets,
		Computers,
		AutoStuff,
	}
}
