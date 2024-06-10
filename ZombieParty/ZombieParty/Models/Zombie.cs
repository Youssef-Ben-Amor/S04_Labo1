using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ZombieParty.Models
{
    public class Zombie
    {
        [key]
        public int Id { get; set; }


        [MinLength(5, ErrorMessage = "Entre 5 et 20 charchtères"),MaxLength(20,ErrorMessage = "Entre 5 et 20 charchtères")]
        public string Name { get; set; }


        // FACULTATIF on peut formellement identifier le champ lien
        // sinon le champ de foreignKey sera auto généré dans la BD
        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        public int ZombieTypeId { get; set; }


        //Propriété de navigationpour la relation 1 à plusieurs avec ZombieType
        [ValidateNever]
        public virtual ZombieType? ZombieType { get; set; }


        [Range(1, 20,ErrorMessage = "Entre 1 et 20")]
        public int Point { get; set; }


        [MaxLength(255, ErrorMessage = "255 charchtères Maximum")]
        public string ShortDEsc { get; set; }
    }
}
