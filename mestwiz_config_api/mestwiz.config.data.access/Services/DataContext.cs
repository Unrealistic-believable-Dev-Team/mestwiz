using mestwiz.config.data.access.Interfaces;
using mestwiz.config.data.entities;
using mestwiz.config.data.entities.Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace mestwiz.config.data.access.Services
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<ApiEndPoint> ApiEndPoints { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SessionXUser> SessionXUsers { get; set; }
        public DbSet<TokenXUser> TokenXUsers { get; set; }
        public DbSet<EmailXUser> EmailXUsers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<PermissionXType> PermissionXTypes { get; set; }
        public DbSet<PermissionXRole> PermissionXRoles { get; set; }
        public DbSet<PhoneXUser> PhoneXUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleXUser> RoleXUsers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuXRole> MenuXRoles { get; set; }

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseLazyLoadingProxies(false).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).UseMySQL(Settings.DBConnectionString.SimpleDecrypt().Result);
        }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Permission>().HasData(new Permission()
            {
                created_date= DateTime.Now,
                description = "Prueba 1",
                route = "api/Config/Auth/Prueba",
                created_user_id = "init",
                status = "AC",
                id = 1
            });

            modelBuilder.Entity<PermissionType>().HasData(new PermissionType()
            {
                created_date = DateTime.Now,
                created_user_id = "init",
                status = "AC",
                method= "GET",
                id = 1
            },
            new PermissionType()
            {
                created_date = DateTime.Now,
                created_user_id = "init",
                status = "AC",
                method = "POST",
                id = 2
            },
            new PermissionType()
            {
                created_date = DateTime.Now,
                created_user_id = "init",
                status = "AC",
                method = "PUT",
                id = 3
            },
            new PermissionType()
            {
                created_date = DateTime.Now,
                created_user_id = "init",
                status = "AC",
                method = "DELETE",
                id = 4
            });

            modelBuilder.Entity<Role>().HasData(new Role()
            {
                name = "Default",
                created_date= DateTime.Now,
                created_user_id = "init",
                status = "AC",
                id = 1
            });

            modelBuilder.Entity<PermissionXType>().HasData(new PermissionXType()
            {
                status = "AC",
                perm_id = 1,
                permt_id = 1,
                id = 1
            },
            new PermissionXType()
            {
                status = "AC",
                perm_id = 1,
                permt_id = 2,
                id = 2
            },
            new PermissionXType()
            {
                status = "AC",
                perm_id = 1,
                permt_id = 3,
                id = 3
            },
            new PermissionXType()
            {
                status = "AC",
                perm_id = 1,
                permt_id = 4,
                id = 4
            });

            modelBuilder.Entity<PermissionXRole>().HasData(new PermissionXRole()
            {
                status = "AC",
                perm_id = 1,
                role_id = 1,
                id = 1
            });

            string user_id = await new User().GetNewId();

            modelBuilder.Entity<User>().HasData(new User()
            {
                status = "AC",
                cipher_secret= "",
                cipher_type = "mb5",
                full_name = "User Default",
                id = user_id,
                name = "user",
                password = await ("pruebas").MD5Encrypt(),
                created_date= DateTime.Now
            });

            modelBuilder.Entity<RoleXUser>().HasData(new RoleXUser()
            {
                role_id = 1,
                status = "AC",
                user_id= user_id,
                id = 1
            });

            modelBuilder.Entity<EmailXUser>().HasData(new EmailXUser()
            {
                created_date = DateTime.Now,
                id = "emanuelpezlara@gmail.com",
                status = "AC",
                user_id= user_id,
                _default = true
            });

            modelBuilder.Entity<PhoneXUser>().HasData(new PhoneXUser()
            {
                created_date = DateTime.Now,
                _default = true,
                status  = "AC",
                user_id= user_id,
                id = "+524778571644"
            });

            modelBuilder.Entity<Menu>().HasData(new Menu()
            {
               created_date = DateTime.Now,
               created_user_id= user_id,
               description  = "Prueba Parent 1",
               id= 1,
               parent_id = 0,
               status = "AC",
               route = ""
            },
            new Menu()
            {
                created_date = DateTime.Now,
                created_user_id = user_id,
                description = "Prueba Parent 2",
                id = 2,
                parent_id = 0,
                status = "AC",
                route = ""
            },
            new Menu()
            {
                created_date = DateTime.Now,
                created_user_id = user_id,
                description = "Administration",
                id = 3,
                parent_id = 1,
                status = "AC",
                route = ""
            },
            new Menu()
            {
                created_date = DateTime.Now,
                created_user_id = user_id,
                description = "Child 2 Parent 1",
                id = 4,
                parent_id = 1,
                status = "AC",
                route = ""
            },
            new Menu()
            {
                created_date = DateTime.Now,
                created_user_id = user_id,
                description = "API EndPoints",
                id = 5,
                parent_id = 3,
                status = "AC",
                route = "/administration/ApiEndPoint"
            });


            modelBuilder.Entity<MenuXRole>().HasData(new MenuXRole()
            {
                created_date = DateTime.Now,
                created_user_id=user_id,
                id = 1,
                role_id = 1,
                menu_id = 1,
                status = "AC"
            },
            new MenuXRole()
            {
                created_date = DateTime.Now,
                created_user_id = user_id,
                id = 2,
                role_id = 1,
                menu_id = 2,
                status = "AC"
            },
            new MenuXRole()
            {
                created_date = DateTime.Now,
                created_user_id = user_id,
                id = 3,
                role_id = 1,
                menu_id = 3,
                status = "AC"
            },
            new MenuXRole()
            {
                created_date = DateTime.Now,
                created_user_id = user_id,
                id = 4,
                role_id = 1,
                menu_id = 4,
                status = "AC"
            },
            new MenuXRole()
            {
                created_date = DateTime.Now,
                created_user_id = user_id,
                id = 5,
                role_id = 1,
                menu_id = 5,
                status = "AC"
            });

        }

       
    }
}