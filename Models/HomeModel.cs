namespace ShopBuy7.Models
{
    public class HomeModel
    {
        public List<Product> Products { get; set; } = new ();
        public List<Banner> Banners { get; set; } = new ();
        public List<Category> Categories { get; set; } = new ();
    }
}
