using System.ComponentModel.DataAnnotations;

namespace KostaAzureFunction
{
    public class Order
    {
        [Key]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}