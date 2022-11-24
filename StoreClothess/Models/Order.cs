using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;

namespace StoreClothess.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Имя клиента")]
        [StringLength(25)]
        [Required(ErrorMessage = "Пожалуйста, введите имя покупателя!")]
        public string Name { get; set; }

        [Display(Name = "Фамилия клиента")]
        [StringLength(35)]
        [Required(ErrorMessage = "Пожалуйста, введите фамилию покупателя!")]
        public string Surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(60)]
        [Required(ErrorMessage = "Пожалуйста, введите корректный адрес покупателя!")]
        public string Adress { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Номер должен содержать не более 11 цифр!Например, +71234567891")]
        public string Phone { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-mail введен некорректно")]
        public string Email { get; set; }

        [Display(Name = "Дата заказа")]
        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime OrderTame { get; set; }

        public List<OrderDetail> orderDetail { get; set; }
    }
}
