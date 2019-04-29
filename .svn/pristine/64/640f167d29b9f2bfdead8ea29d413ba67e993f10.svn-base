using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PORTAL.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public override string Email { get; set; }

        [Required]
        public bool MustChangePW { get; set; }

        [Required]
        public long CompanyId { get; set; }

        [Required]
        public long ContactId { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            //userIdentity.AddClaim(new Claim("CompanyId", CompanyId.ToString()));
            //userIdentity.AddClaim(new Claim("FirstName", FirstName));
            //userIdentity.AddClaim(new Claim("LastName", LastName));
            //userIdentity.AddClaim(new Claim("Email", Email));
            //userIdentity.AddClaim(new Claim("MustChangePW", MustChangePW.ToString()));
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        //protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<IdentityUser>()
        //            .ToTable("CONTACTS", "dbo").Property(p => p.Id).HasColumnName("User_Id");

        //    modelBuilder.Entity<IdentityUser>().ToTable("CONTACTS").Property(p => p.Id).HasColumnName("UserId");
        //    modelBuilder.Entity<ApplicationUser>().ToTable("CONTACTS").Property(p => p.Id).HasColumnName("UserId");
        //    modelBuilder.Entity<IdentityUserRole>().ToTable("MyUserRoles");
        //    modelBuilder.Entity<IdentityUserLogin>().ToTable("MyUserLogins");
        //    modelBuilder.Entity<IdentityUserClaim>().ToTable("MyUserClaims");
        //    modelBuilder.Entity<IdentityRole>().ToTable("MyRoles");
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }


    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return rm.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(ApplicationUser user, string password)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                //MHRIPKO Commto
                //um.RemoveFromRole(userId, role.Role.Name);
            }
        }
    }

    
}