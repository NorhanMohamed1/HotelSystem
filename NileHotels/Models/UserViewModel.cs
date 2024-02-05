namespace NileHotels.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public List<string> Roles { get; set; }

        public string RoleId { get; set; } // Add this property
        public string RoleName { get; set; } // Add this property
        public bool IsSelected { get; set; }
    }
}
