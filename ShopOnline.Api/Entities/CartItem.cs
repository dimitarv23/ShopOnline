namespace ShopOnline.Api.Entities
{
    public class CartItem
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
