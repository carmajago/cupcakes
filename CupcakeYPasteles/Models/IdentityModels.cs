using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CupcakeYPasteles.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
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

        public System.Data.Entity.DbSet<CupcakeYPasteles.Models.Gasto> Gastoes { get; set; }

        public System.Data.Entity.DbSet<CupcakeYPasteles.Models.Ingreso> Ingresoes { get; set; }

        public System.Data.Entity.DbSet<CupcakeYPasteles.Models.DineroEnCaja> DineroEnCajas { get; set; }

        public System.Data.Entity.DbSet<CupcakeYPasteles.Models.Producto> Productoes { get; set; }

        public System.Data.Entity.DbSet<CupcakeYPasteles.Models.Material> Materials { get; set; }
    }
}