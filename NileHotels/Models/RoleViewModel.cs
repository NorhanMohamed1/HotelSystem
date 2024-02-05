using System.ComponentModel.DataAnnotations;

namespace NileHotels.Models
{
    public class RoleViewModel
    {
        
        [Required]
        public string RoleName { get; set; }
    }
}
