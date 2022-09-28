namespace Eshop.Models
{
	public class Basket
	{
		public int BasketID { get; set; }

		public string Name { get; set; } = string.Empty;

		public int UserID { get; set; }

		public List<BasketProduct> Products { get; set; } = new();



	}
}
