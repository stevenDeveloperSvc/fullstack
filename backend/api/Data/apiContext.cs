
using api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace api.Data
{
    public partial class apiContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        //    optionsBuilder.UseSqlServer("Data Source=DEV3\\SQLEXPRESS;Initial Catalog=Data; Integrated Security=True;");

        }
        public apiContext(DbContextOptions<apiContext> options)
        : base(options)

        {

        }


        public DbSet<PermissionType> permissionTypes { get; set; }
        public DbSet<RolePermission> rolePermissions { get; set; }
        public DbSet<RoleType> roleTypes { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserPermission> userPermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }




    }
}

