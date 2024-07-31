namespace WebApp_ASPNET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Sexe> Sexes { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sexe>().ToTable("Sexe");
            modelBuilder.Entity<Contact>().ToTable("Contact");

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Sexe)
                .WithMany()
                .HasForeignKey(c => c.Genre);
        }
    }
}
