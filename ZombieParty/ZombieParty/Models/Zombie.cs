﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ZombieParty.Models
{
    public class Zombie
    {
        [key]
        public int Id { get; set; }
        public string Name { get; set; }
        // FACULTATIF on peut formellement identifier le champ lien
        // sinon le champ de foreignKey sera auto généré dans la BD
        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        public int ZombieTypeId { get; set; }
        //Propriété de navigationpour la relation 1 à plusieurs avec ZombieType

        public ZombieType ZombieType { get; set; }
        public int Point { get; set; }
    }
}
