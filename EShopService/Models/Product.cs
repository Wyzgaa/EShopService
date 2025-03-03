namespace EShopService.Models
{
    public class Product : BaseModel
    {
        public int id { get; set; }
        public string name { get; set; } = default!;
        public string ean { get; set; } = default!;
        public int stock { get; set; }
        public string sku { get; set; } = default!;
        public Category category { get; set; } = default!;
        public decimal price { get; set; }
    }
}
