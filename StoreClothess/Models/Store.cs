namespace StoreClothess.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Display(Name = "Название магазина")]
        [Required(ErrorMessage = "Пожалуйста, введите название магазина")]

        public string Stores { get; set; }

        [MaxLength(20)]
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Пожалуйста, введите адрес магазина")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Номер должен содержать не более 11 цифр!Например, +71234567891")]
        public string Phone { get; set; }
    }
}
