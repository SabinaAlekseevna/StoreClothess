namespace StoreClothess.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal Prise { get; set; }
        public virtual Product product { get; set; }
        public virtual Order order { get; set; }

    }
}
