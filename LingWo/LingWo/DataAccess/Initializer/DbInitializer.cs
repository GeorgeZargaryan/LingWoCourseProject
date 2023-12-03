using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LingWo.DataAccess.Data;
using LingWo.Models;
using LingWo.Utility;

namespace LingWo.DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Any())
                    _db.Database.Migrate();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            if(!_roleManager.RoleExistsAsync(WC.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WC.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WC.UserRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WC.GuestRole)).GetAwaiter().GetResult();
            }
            else
                return;

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "georgezargaryan7@gmail.com",
                Email = "georgezargaryan7@gmail.com",
                EmailConfirmed = true,
                FullName = "George Zargaryan",
                PhoneNumber = "+374 93 158 870"
            }, password: "Something2005!").GetAwaiter().GetResult();

            var user = _db.Users.FirstOrDefault(u => u.Email == "georgezargaryan7@gmail.com");
            _userManager.AddToRoleAsync(user, WC.AdminRole).GetAwaiter().GetResult();
        }
    }
}