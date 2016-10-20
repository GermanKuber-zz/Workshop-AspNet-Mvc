using System.Data.Entity;
using System.Diagnostics;
using ManagerUtn.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ManagerUtn.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Comment> Comentarios { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}