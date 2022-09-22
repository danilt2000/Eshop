namespace Eshop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; }

        public int BasketID { get; set; }

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
