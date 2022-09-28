namespace Eshop.Models
{
    public class BasketProduct
    {
        public int BasketId { get; set; }

        public Basket Basket { get; set; } = new();

        public int ProductId { get; set; }

        public Product Product { get; set; } = new();

    }
}
