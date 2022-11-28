using System.ComponentModel.DataAnnotations;

namespace StoreClothess.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Display(Name = "ФИО")]
        public string Name { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Должность")]
        public string Employee { get; set; }

        [Display(Name = "Часы работы")]
        public int Times { get; set; }

        [Display(Name = "Оплата")]
        public decimal price { get; set; }


        [Display(Name = "Пользователь")]
        public string? UserID { get; set; }
    }
}
