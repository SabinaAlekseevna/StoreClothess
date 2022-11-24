namespace StoreClothess.Models
{
    public class Condition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Conditions { get; set; }
    }
}
