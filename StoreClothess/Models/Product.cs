namespace StoreClothess.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(20)]
        [Display(Name = "Наименование товара")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public string Name { get; set; }

        [MaxLength(20)]
        [Display(Name = "Цвет")]
        [Required(ErrorMessage = "Пожалуйста, введите цвет товара")]
        public string Colour { get; set; }

        [MaxLength(3)]
        [Display(Name = "Размер")]
        [Required(ErrorMessage = "Пожалуйста, введите размер товара")]
        public string Size { get; set; }

        [MaxLength(4)]
        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Пожалуйста, введите количество товара")]
        public int Quantity { get; set; }

        [MaxLength(20)]
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public decimal Prise { get; set; }

        [ForeignKey("Store")]
        
        [Display(Name = "Магазин")]
        public int? StoreId { get; set; }


        public virtual Store? Store { get; set; }
    }
}
