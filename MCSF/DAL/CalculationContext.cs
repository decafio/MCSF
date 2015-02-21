using MCSF.ApiModels;
using System.Data.Entity; // Need System.Data.Entity.Design
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MCSF.DAL
{
    public class CalculationContext : DbContext
    {

        public CalculationContext()
            : base("CalculationContext")
        {
        }

        public DbSet<AdditionalChildren> AdditionalChildren { get; set; }
        public DbSet<GeneralCareSupport> GeneralCareSupports { get; set; }
        public DbSet<IncomeBracket> IncomeBrackets { get; set; }
        public DbSet<LowIncomeThreshold> LowIncomeThresholds { get; set; }
        public DbSet<OrdinaryMedicalExpense> OrdinaryMedExps { get; set; }
        public DbSet<TransitionAdjustment> TransitionAdjustments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransitionAdjustment>().Property(x => x.Multiplier).HasPrecision(3, 2);
            modelBuilder.Entity<OrdinaryMedicalExpense>().Property(x => x.MonthlyAmount).HasPrecision(8, 2);
            modelBuilder.Entity<GeneralCareSupport>().Property(x => x.BasePercent).HasPrecision(5, 4);
            modelBuilder.Entity<GeneralCareSupport>().Property(x => x.BasePercent).HasPrecision(8, 2);
            modelBuilder.Entity<GeneralCareSupport>().Property(x => x.MarginalPercent).HasPrecision(5, 4);
            modelBuilder.Entity<AdditionalChildren>().Property(x => x.Multiplier).HasPrecision(5, 4);
        }
    }
}