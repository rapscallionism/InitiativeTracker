using Core.Models.Entities;
using Core.Models.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Database
{
    public class AppDbContext : DbContext
    {
        // Comparators, to be used when converting of tags, equipmentslots, and resetters
        private readonly ValueComparer stringArrayComparer = new ValueComparer<Core.Models.Utilities.Tags[]>(
            (a, b) => a.SequenceEqual(b),
            a => a.Aggregate(0, (x, y) => HashCode.Combine(x, y.GetHashCode())),
            a => a.ToArray()
        );

        private readonly ValueComparer slotArrayComparer = new ValueComparer<EquipmentSlot[]>(
            (a, b) => a.SequenceEqual(b),
            a => a.Aggregate(0, (x, y) => HashCode.Combine(x, y.GetHashCode())),
            a => a.ToArray()
        );

        private readonly ValueComparer resetArrayComparer = new ValueComparer<ResetsOn[]>(
            (a, b) => a.SequenceEqual(b),
            a => a.Aggregate(0, (x, y) => HashCode.Combine(x, y.GetHashCode())),
            a => a.ToArray()
        );

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

            // -------------------------
            // EquipmentEntity Config
            // -------------------------
            modelBuilder.Entity<EquipmentEntity>(entity =>
            {
                entity.ToTable("equipments");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                      .HasMaxLength(500);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                // These are arrays – EF Core cannot store arrays natively.
                // They will default to non-mapped unless configured as JSON.
                entity.Property(e => e.Tags)
                  .HasConversion(
                      v => string.Join(",", v.Select(x => x.ToString())),
                      v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => Enum.Parse<Core.Models.Utilities.Tags>(s))
                            .ToArray()
                  )
                  .Metadata.SetValueComparer(stringArrayComparer);

                entity.Property(e => e.EquipmentSlot)
                    .HasConversion(
                        v => string.Join(",", v.Select(x => x.ToString())),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => Enum.Parse<EquipmentSlot>(s))
                            .ToArray()
                    )
                    .Metadata.SetValueComparer(slotArrayComparer);

                // Relationship: Equipment has many Features
                entity.HasMany(e => e.Features)
                      .WithOne(f => f.Equipment)
                      .HasForeignKey(f => f.EquipmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // -------------------------
            // Feature Config
            // -------------------------
            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("features");

                entity.HasKey(f => f.Id);

                entity.Property(f => f.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(f => f.Description)
                      .HasMaxLength(2000);

                // Enum → string or int (your choice)
                entity.Property(f => f.ActionEconomyType)
                      .HasConversion<string>();

                entity.Property(e => e.ResetsOn)
                      .HasConversion(
                          v => string.Join(",", v.Select(x => x.ToString())),
                          v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(s => Enum.Parse<Core.Models.Utilities.ResetsOn>(s))
                                .ToArray()
                      )
                      .Metadata.SetValueComparer(resetArrayComparer);

                // Optional FK handled by relationship above
                entity.Property(f => f.EquipmentId)
                      .IsRequired(false);
            });
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<EquipmentEntity> Equipments { get; set; }
    }
}
