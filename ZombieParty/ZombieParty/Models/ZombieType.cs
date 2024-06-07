using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class ZombieType
    {
        [key]
        public int Id { get; set; }


        [MinLength(5, ErrorMessage = "Entre 5 et 10 charchtères"), MaxLength(10, ErrorMessage = "Entre 5 et 10 charchtères")]
        [DisplayName("Type Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} has to be filled.")]
        public string TypeName { get; set; }


        [Range(1, 20, ErrorMessage = "Entre 2 et 5")]
        public int Point;
    }
}
