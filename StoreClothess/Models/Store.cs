namespace StoreClothess.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Stores { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }
    }
}
