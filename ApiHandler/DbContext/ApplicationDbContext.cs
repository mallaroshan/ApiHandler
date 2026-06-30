using ApiHandler.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApiHandler.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApiConfiguration> ApiConfigurations => Set<ApiConfiguration>();
    public DbSet<FieldMapping> FieldMappings => Set<FieldMapping>();
    public DbSet<FieldMapping> ResponseMappings => Set<FieldMapping>();
    public DbSet<Pipeline> Pipelines => Set<Pipeline>();
    public DbSet<PipelineLog> PipelineLogs => Set<PipelineLog>();
    public DbSet<ExternalApi> ExternalApis => Set<ExternalApi>();

    public DbSet<ApiHeader> ApiHeaders => Set<ApiHeader>();

    public DbSet<RequestParameter> RequestParameters => Set<RequestParameter>();

    public DbSet<ResponseParameter> ResponseParameters => Set<ResponseParameter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApiConfiguration>()
            .HasMany(x => x.FieldMappings)
            .WithOne(x => x.ApiConfiguration)
            .HasForeignKey(x => x.ApiConfigurationId);

        modelBuilder.Entity<Pipeline>()
            .HasOne(x => x.ApiConfiguration)
            .WithMany()
            .HasForeignKey(x => x.ApiConfigurationId);

        modelBuilder.Entity<PipelineLog>()
            .HasOne(x => x.Pipeline)
            .WithMany()
            .HasForeignKey(x => x.PipelineId);

        modelBuilder.Entity<ExternalApi>()
            .HasMany(x => x.Headers)
            .WithOne(x => x.ExternalApi)
            .HasForeignKey(x => x.ExternalApiId);

        modelBuilder.Entity<ExternalApi>()
            .HasMany(x => x.RequestParameters)
            .WithOne(x => x.ExternalApi)
            .HasForeignKey(x => x.ExternalApiId);

        modelBuilder.Entity<ExternalApi>()
            .HasMany(x => x.ResponseParameters)
            .WithOne(x => x.ExternalApi)
            .HasForeignKey(x => x.ExternalApiId);
    }
}