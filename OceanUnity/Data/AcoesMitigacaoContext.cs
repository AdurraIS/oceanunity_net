using Microsoft.EntityFrameworkCore;
using oceanunity.entities;

namespace oceanunity.data;

public class AcoesMitigacaoContext: DbContext
{
    public DbSet<AcoesMitigacao> acoes {get; set;}

    public AcoesMitigacaoContext(DbContextOptions<AcoesMitigacaoContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcoesMitigacao>().ToTable("tb_acoes_mitigacao");
    }
}