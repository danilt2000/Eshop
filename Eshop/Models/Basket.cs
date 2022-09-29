namespace Eshop.Models
{
	public class Basket
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string UserID { get; set; }

		public List<BasketProduct> Products { get; set; } = new();



	}
}
