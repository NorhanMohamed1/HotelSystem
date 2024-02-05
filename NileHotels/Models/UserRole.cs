namespace NileHotels.Models
{
    public class UserRole
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string[] SelectedRolesId { get; set; } //SelectedRoleNames
        public List<RoleViewModell> Roles { get; set; }

        public UserRole()
        {
            Roles = new List<RoleViewModell>();
        }
    }

    public class RoleViewModell
    {
        // Adjust the properties based on your actual requirements
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
     
}
