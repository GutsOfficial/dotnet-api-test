using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace testapi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage = "selammmmm")]

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
