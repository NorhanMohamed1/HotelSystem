using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NileHotels.Models;
using System.Data;
using System.Threading.Tasks;

namespace NileHotels.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
     

        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
           
        }

        public IActionResult Users()
        { 
            #region users
            var users = _userManager.Users.Select(u => new UserRole
            {
                UserId = u.Id,
                UserName = u.UserName,

            }).ToList();

            ViewData["UsersWithRoles"] = users;
            #endregion

            #region roles
            

            var roles = _roleManager.Roles.Select(role => new RoleViewModell
            {
                RoleId = role.Id,
                RoleName = role.Name,
                IsSelected = false // or set to true based on your requirements
            }).ToList();

            ViewData["Roles"] = roles;
            #endregion
            return View();
        }

        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                // Handle the case where the user is not found, for example, return a JSON object with an error message
                return Json(new { error = "User not found" });
            }

            // Retrieve the roles for the user
            var roles = await _userManager.GetRolesAsync(user);


            // Create a UserRole object and populate its properties
            var userRole = new UserRole
            {
                UserId = user.Id,
                UserName = user.UserName,
                SelectedRolesId = roles.ToArray()
            };

            

            return Json(userRole);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserRole model, string userId )
        {
             
             var user = await _userManager.FindByIdAsync(userId);
                 
            if (user != null)
            {
                foreach (var roleid in model.SelectedRolesId)
                {
                    var selectedRole = await _roleManager.FindByIdAsync(roleid);
                    if (selectedRole != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, selectedRole.Name);

                        if (result.Succeeded)
                        {
                            // User successfully added to the role, you may want to redirect to a success page or do something else
                            return RedirectToAction("Users", "Roles");
                        }
                        else
                        {
                            // Handle the case where adding user to the role fails
                            ModelState.AddModelError("", "Failed to add user to the role");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Role not found");
                    }
                }
               
            }
           
            // If the model state is not valid, return to the form with errors
            return RedirectToAction("Users", "Roles");



            // Add or remove roles based on the IsSelected property
            //foreach (var role in model.Roles)
            //{
            //    if (role.IsSelected)
            //        await _userManager.AddToRoleAsync(user, role.RoleName);
            //    else
            //        await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            //}

        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserRole(string userId,string RoleName)
        {
            // Assuming UserRoleRemoveRequest is a class with UserId and RoleName properties
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, RoleName);

            if (result.Succeeded)
            {
                return Ok(new { success = true });
            }
            else
            {
                return BadRequest(new { error = "Failed to remove role" });
            }
        }



        public IActionResult GetAllRoles()
        { 
            var roles = _roleManager.Roles.Select(role => new RoleViewModell
            {
                RoleId = role.Id,
                RoleName = role.Name,
                //IsSelected = false // or set to true based on your requirements
            }).ToList();


            return Json(roles);

        }



        //var user = await _userManager.FindByIdAsync("1");
        //var model = new List<RoleViewModell>();
        //foreach (var role in _roleManager.Roles)
        //{
        //    var userRolesViewModel = new RoleViewModell
        //    {
        //        RoleId = role.Id,
        //        RoleName = role.Name,
        //    };
        //    if (await _userManager.IsInRoleAsync(user, role.Name))
        //    {
        //        userRolesViewModel.IsSelected = true;
        //    }
        //    else
        //    {
        //        userRolesViewModel.IsSelected = false;
        //    }
        //    model.Add(userRolesViewModel);
        //}
        //var roles = _roleManager.Roles.Select(role => new RoleViewModell
        //{
        //    RoleId = role.Id,
        //   RoleName = role.Name,
        //}).ToList();

        
         


        // Add other actions as needed
        [HttpGet]
        public IActionResult CreateRoles()
        {
            var roles = _roleManager.Roles.Select(r => new RoleViewModel
            { 
                RoleName = r.Name
            }).ToList();

             
            ViewData["Roles"] = roles;
             

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole 
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync (identityRole);

                if(result.Succeeded)
                {
                    return RedirectToAction("CreateRoles", "Roles");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }

           

            return RedirectToAction("CreateRoles", "Roles"); ;
        }


        //public async Task<IActionResult> Create(string roleName)
        //{
        //    if (string.IsNullOrWhiteSpace(roleName))
        //    {
        //        ModelState.AddModelError("RoleName", "Role name cannot be empty");
        //        return View();
        //    }

        //    var roleExist = await _roleManager.RoleExistsAsync(roleName);
        //    if (roleExist)
        //    {
        //        ModelState.AddModelError("RoleName", "Role already exists");
        //        return View();
        //    }

        //    var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

        //    if (result.Succeeded)
        //    {
        //        // Role created successfully
        //        return RedirectToAction("Index", "Home"); // Redirect to home or another page
        //    }

        //    // If there are errors, add them to the model state
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error.Description);
        //    }

        //    return View();
        //}

    }
}
