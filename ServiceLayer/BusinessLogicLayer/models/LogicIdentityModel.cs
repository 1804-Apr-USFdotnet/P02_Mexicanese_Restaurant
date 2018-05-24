using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.models
{
    public class LogicIdentityModel
    {
        [Key]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        
    }
}
