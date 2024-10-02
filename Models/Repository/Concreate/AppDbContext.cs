using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Models.Repository.Concreate
{

    //IdentityDbContext context sınıfından miras alır
    public class AppDbContext :IdentityDbContext
    {

        
        public DbSet<Brand> brands { get; set; }
        public DbSet<CarModel> models { get; set; }

        public DbSet<Car> cars { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        //ModelBuilder, veritabanı ve varlık sınıfları arasındaki bağlantıları tanımlamaya yarayan bir nesnedir
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Bu metod, EF Core'da model oluşturma işlemi sırasında çağrılır ve varlık sınıfları arasındaki ilişkileri, özelliklerin nasıl eşleneceğini (mapping) vb. belirlemek için kullanılır.
        {
            // Brand ve Model arasında One-to-Many ilişki
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.carModels)
                .WithOne(m => m.brand)
                .HasForeignKey(m => m.brandId);

            // Model ve Car arasında One-to-Many ilişki
            modelBuilder.Entity<CarModel>()
                .HasMany(m => m.cars)
                .WithOne(c => c.model)
                .HasForeignKey(c => c.modelId);

            base.OnModelCreating(modelBuilder);

           
        }
    

    

        
    }
}
