namespace StoreClothess.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Colour { get; set; }

        [Required]
        [MaxLength(6)]
        public string Size { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Prise { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }


        public virtual Store? Store { get; set; }
    }
}
