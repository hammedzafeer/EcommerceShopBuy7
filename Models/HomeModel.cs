namespace ShopBuy7.Models
{
    public class HomeModel
    {
        public List<Product> Products { get; set; } = new ();
        public List<Product> Featured { get; set; } = new ();
        public List<Product> OnSale { get; set; } = new ();
        public List<Product> TopRated { get; set; } = new ();
        public List<Deal> Deals { get; set; } = new ();
        public List<Product> Top20 { get; set; } = new();
        public List<Product> Phones { get; set; } = new();
        public List<Product> Laptops { get; set; } = new();
        public List<Banner> Banners { get; set; } = new ();
        public List<Category> Categories { get; set; } = new ();
        public List<SubCategory> SubCategories { get; set; } = new ();
    }
}

