using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using EC_Ecom2.Models.Products;
using EC_Ecom2.Models.Checkout;
using EC_Ecom2.Models.Users;

namespace EC_Ecom2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int ProfileId { get; set; }
        //public Profile Profile { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Cartitem> Cartitems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Orderitem> Orderitems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public System.Data.Entity.DbSet<EC_Ecom2.Models.Checkout.CartViewModel> CartViewModels { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public System.Data.Entity.DbSet<EC_Ecom2.Models.App.Admin> Admins { get; set; }
    }
}