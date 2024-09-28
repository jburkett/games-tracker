using GamesTracker.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesTracker.DataAccess.Postgres;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Game")
            .HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(255)
            .IsRequired();
    }
}
