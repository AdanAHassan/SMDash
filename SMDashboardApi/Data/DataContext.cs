namespace SMDashboardApi.Data;

public class DataContext : DbContext
{
    // Saves you from debugging silly errors caused by editing the connection string format
    private readonly string hostString = "localhost";
    private readonly string dbString = "SMDashboardDB";
    private readonly string userString = "exampleUser";
    private readonly string pwString = "examplePassword";

    public DataContext(DbContextOptions<DataContext> options) : base(options){
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string ConnectionString = $"Server={hostString};Database={dbString};User Id={userString};Password={pwString};trustServerCertificate=yes;";
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<PlatformDataset> PlatformDatasets { get; set; }
    public DbSet<PlatformMetric> PlatformMetrics { get; set; }
    public DbSet<MetricProgress> MetricProgressList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
          .Property(x => x.Id)
          .ValueGeneratedOnAdd();

        modelBuilder.Entity<PlatformDataset>()
          .Property(x => x.Id)
          .ValueGeneratedOnAdd();

        modelBuilder.Entity<PlatformMetric>()
          .Property(x => x.Id)
          .ValueGeneratedOnAdd();

        modelBuilder.Entity<MetricProgress>()
          .Property(x => x.Id)
          .ValueGeneratedOnAdd();

        modelBuilder.Entity<PlatformMetric>()
          .HasMany<MetricProgress>(x => x.ProgressList)
          .WithOne()
          .HasForeignKey(x => x.PlatformMetricId)
          .IsRequired();

        modelBuilder.Entity<PlatformDataset>()
          .HasMany<PlatformMetric>(x => x.PlatformMetrics)
          .WithOne()
          .HasForeignKey(x => x.PlatformDatasetId)
          .IsRequired();

        modelBuilder.Entity<Client>()
          .HasMany<PlatformDataset>(x => x.PlatformDatasets)
          .WithOne()
          .HasForeignKey(x => x.ClientId)
          .IsRequired();



    //     modelBuilder.Entity<MetricProgress>()
    //       .HasOne<PlatformMetric>()
    //       .WithMany(x => x.ProgressList)
    //       .HasForeignKey(x => x.PlatformMetricId)
    //       .IsRequired();
    //
    //     modelBuilder.Entity<PlatformMetric>()
    //       .HasOne<PlatformDataset>()
    //       .WithMany(x => x.PlatformMetrics)
    //       .HasForeignKey(x => x.PlatformDatasetId)
    //       .IsRequired();
    //
    //     modelBuilder.Entity<PlatformDataset>()
    //       .HasOne<Client>()
    //       .WithMany(x => x.PlatformDatasets)
    //       .HasForeignKey(x => x.ClientId)
    //       .IsRequired();
   }
}
