using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class HuntingLog
    {
        public int Id { get; set; }
        [Range(2, 25, ErrorMessage = "Entre 2 et 25")]
        public string Title { get; set; }
        [MaxLength(255, ErrorMessage = "255 charchtères Maximum")]
        public string Description { get; set; }
        public List<Zombie> Zombie { get; set; }

    }
}
