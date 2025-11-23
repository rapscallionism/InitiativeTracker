using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<ActionEntity> Actions;
        public DbSet<BonusActionEntity> BonusActions;
        public DbSet<EffectEntity> Effects;
        public DbSet<ReactionEntity> Reactions;
        public DbSet<EquipmentEntity> Equipments;
    }
}
