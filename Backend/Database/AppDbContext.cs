using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ActionEntity> Actions { get; set; }
        public DbSet<BonusActionEntity> BonusActions { get; set; }
        public DbSet<EffectEntity> Effects { get; set; }
        public DbSet<ReactionEntity> Reactions { get; set; }
        public DbSet<EquipmentEntity> Equipments { get; set; }
    }
}
