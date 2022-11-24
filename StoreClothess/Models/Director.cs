namespace StoreClothess.Models
{
    public class Director : Person
    {
        public virtual User? User { get; set; }
    }
}
