namespace StoreClothess.Models
{
    public class OrderProductId
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }

        public string ProductStoreOrderId { get; set; }
    }
}
