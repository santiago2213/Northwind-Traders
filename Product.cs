namespace Santiago_HW3
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public bool PromoFront { get; set; }
        public bool PromoDept { get; set; }
        public string AvailableQty { get; set; }
        public string TargetLevel { get; set; }
    }
}