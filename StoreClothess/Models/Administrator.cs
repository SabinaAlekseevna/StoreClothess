namespace StoreClothess.Models
{
    public class Administrator : Person
    {
        [Display(Name = "Магазин")]
        public int? StoreID { get; set; }
        public virtual Store? Store { get; set; }
        public virtual User? User { get; set; }
    }
}
