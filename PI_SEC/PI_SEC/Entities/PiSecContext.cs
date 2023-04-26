using Microsoft.EntityFrameworkCore;

namespace PI_SEC.Entities;

public partial class PiSecContext : DbContext
{
    public PiSecContext()
    {
    }

    public PiSecContext(DbContextOptions<PiSecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    private readonly string? _connectionString;
    public PiSecContext(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("ConnectionString can't be empty");
        }
        _connectionString = connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (!string.IsNullOrEmpty(_connectionString))
        {
            builder.UseSqlServer(_connectionString);
            base.OnConfiguring(builder);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_100_CI_AS");

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
