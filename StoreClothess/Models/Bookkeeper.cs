using System.Text.RegularExpressions;

namespace StoreClothess.Models
{
    public class Bookkeeper : Person
    {
        public virtual User? User { get; set; }
    }
}
