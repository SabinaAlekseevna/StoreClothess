namespace StoreClothess.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        
        [Display(Name = "Наименование товара")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public string Name { get; set; }

        
        [Display(Name = "Цвет")]
        [Required(ErrorMessage = "Пожалуйста, введите цвет товара")]
        public string Colour { get; set; }

        
        [Display(Name = "Размер")]
        [Required(ErrorMessage = "Пожалуйста, введите размер товара")]
        public string Size { get; set; }

       
        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Пожалуйста, введите количество товара")]
        public int Quantity { get; set; }

        
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public decimal Prise { get; set; }

        [ForeignKey("Store")]
        
        [Display(Name = "Магазин")]
        public int? StoreId { get; set; }


        public virtual Store? Store { get; set; }
    }
}
