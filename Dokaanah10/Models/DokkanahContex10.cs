using Microsoft.EntityFrameworkCore;

namespace Dokaanah10.Models
{
    public class DokkanahContex10:DbContext
    {
        public DokkanahContex10()
        {
            
        }

        public DokkanahContex10(DbContextOptions<DokkanahContex10> options)
        : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Product_Category> Product_Categories { get; set; }
        public virtual DbSet<Cart_Product> Cart_Products { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.
         UseSqlServer("Server=WIN-NDU0OLHD06I\\SQLEXPRESS;Database=DokkanahDataBase10;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Category>()
                .HasKey(e => new { e.Pid, e.Cid });

            modelBuilder.Entity<Cart_Product>()
                .HasKey(e => new { e.Prid, e.Caid });




            //    modelBuilder.Entity<Login>()
            //        .HasIndex(l => l.StudentsId) // Create an index on CustomerId
            //        .IsUnique();
            //    OnModelCreatingPartial(modelBuilder);
            //
        }





        // protect potentially sensitive information in your connection string,
        // you should move it out of source code. You can avoid scaffolding
        // the connection string by using the Name= syntax to read it from
        // configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
        // For more guidance on storing connection strings,
        // see http://go.microsoft.com/fwlink/?LinkId=723263.





    }
}
