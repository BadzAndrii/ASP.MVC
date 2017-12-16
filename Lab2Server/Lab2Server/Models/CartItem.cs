namespace Lab2Server.Models
{
    public class GetCartData
    {
        public GetCartData() { Items = new CartItem[] { }; }

        public CartItem [] Items { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
}